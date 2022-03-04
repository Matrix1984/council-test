using Models.SateliteCoordinatesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.NoteDTOs
{
    public class NoteDTO
    {
        public string NoteId { get; set; }

        public string UserIP { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string Note { get; set; }
    }
}
