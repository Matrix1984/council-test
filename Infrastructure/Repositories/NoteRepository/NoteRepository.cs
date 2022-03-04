using Models.NoteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.NoteRepository
{
    public class NoteRepository : INoteRepository
    {
        private List<NoteDTO> notes = new List< NoteDTO>();
        public NoteDTO AddNote(NoteDTO createNoteDTO)
        {
      

            notes.Add(createNoteDTO);

            return createNoteDTO;
        }

        public List<NoteDTO> ListNotes(string userIP)
        {
            return notes.Where(x=>x.UserIP== userIP).ToList();
        }
    }
}
