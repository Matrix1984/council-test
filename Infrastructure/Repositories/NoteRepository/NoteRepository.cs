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

        public dynamic ListNotes(string userIP)
        {
            return (from n in notes
                   where n.UserIP == userIP
                   select new
                   {
                       noteId= n.NoteId,
                       latitude= n.Longitude,
                       longitude= n.Latitude
                   }).ToList();
        }
    }
}
