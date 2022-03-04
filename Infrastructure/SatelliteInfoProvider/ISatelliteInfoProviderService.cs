using Models.SateliteCoordinatesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SatelliteInfoProvider
{
    public interface ISatelliteInfoProviderService
    {
        Task<SateliteCoordinateDTO> GetSatelliteInfo();
    }
}
