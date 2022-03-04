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
        public SateliteCoordinateDTO SateliteCoordinate { get; set; }
    }
}
