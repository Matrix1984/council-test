using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SateliteCoordinatesDTOs
{ 
    public class SateliteCoordinateDTO
    {
        public Iss_Position iss_position { get; set; }
        public int timestamp { get; set; }
        public string message { get; set; }
    }

    public class Iss_Position
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

}
