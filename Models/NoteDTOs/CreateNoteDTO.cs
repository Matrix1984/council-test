using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.NoteDTOs
{
    public class CreateNoteDTO
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string Note { get; set; }
    }
}
