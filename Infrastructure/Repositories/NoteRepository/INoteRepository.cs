using Models.NoteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.NoteRepository
{
    public interface INoteRepository
    {
        NoteDTO AddNote(NoteDTO createNoteDTO);

        dynamic ListNotes(string userIP);
    }
}
