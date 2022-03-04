using Models.SateliteCoordinatesDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SatelliteInfoProvider
{
    public class SatelliteInfoProviderService : ISatelliteInfoProviderService
    {
        private const int CachWaitTimeRequest = 2;

        private DateTime nextTrendyRequestCacheUpdate = DateTime.UtcNow.AddSeconds(CachWaitTimeRequest);

        private readonly IHttpClientFactory httpClientFactory;

        private SateliteCoordinateDTO sateliteCoordinates; 

        object lockObj = new Object();
        
        TimeSpan timeout = TimeSpan.FromMilliseconds(3000);

        bool lockTaken = false;
        public SatelliteInfoProviderService(IHttpClientFactory clientFactory)
        {
            httpClientFactory = clientFactory;
        }

        public async Task<SateliteCoordinateDTO> GetSatelliteInfo()
        {  
            try
            {
                if(sateliteCoordinates==null || DateTime.UtcNow > nextTrendyRequestCacheUpdate)
                {
                    Monitor.TryEnter(lockObj, timeout, ref lockTaken);

                    if (sateliteCoordinates == null || DateTime.UtcNow > nextTrendyRequestCacheUpdate)
                    {
                        sateliteCoordinates = FetchApiCallData().Result;
                        nextTrendyRequestCacheUpdate = DateTime.UtcNow.AddSeconds(CachWaitTimeRequest);
                    }
                        
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Api Call Log: "+ ex.Message);
            }
            finally
            { 
                if (lockTaken)
                {
                    nextTrendyRequestCacheUpdate = DateTime.UtcNow.AddSeconds(CachWaitTimeRequest);
                    lockTaken = false;
                    Monitor.Exit(lockObj);
                } 
            } 

            return sateliteCoordinates;
        }

        private async Task<SateliteCoordinateDTO> FetchApiCallData()
        {
            var client = this.httpClientFactory.CreateClient("Satellite");

            SateliteCoordinateDTO sateliteRes=new();

            HttpResponseMessage response = await client.GetAsync("http://api.open-notify.org/iss-now.json");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string text = await response.Content.ReadAsStringAsync();

                sateliteRes = JsonConvert.DeserializeObject<SateliteCoordinateDTO>(text);
            }
            else
            {
                throw new Exception("Unsuccessful data fetch attempt");
            }

            if (sateliteRes == null )
                throw new Exception("Unsuccessful data fetch attempt");

            return sateliteRes;
        }
    }
}
