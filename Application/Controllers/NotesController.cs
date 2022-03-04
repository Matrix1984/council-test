using Infrastructure.Repositories.NoteRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.NoteDTOs;
using Models.SateliteCoordinatesDTOs;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository noteRepository;

        private readonly IHttpContextAccessor httpContextAccessor;
        public NotesController(INoteRepository noteRepo,
            IHttpContextAccessor httpContext)
        {
            this.noteRepository = noteRepo;
            this.httpContextAccessor = httpContext;
        }

        [HttpPost]
        public IActionResult SaveNote(CreateNoteDTO createNoteDTO)
        {
            NoteDTO noteDTO = new();
            noteDTO.Latitude = createNoteDTO.Latitude; ;
            noteDTO.Longitude = createNoteDTO.Longitude;
            noteDTO.Note = createNoteDTO.Note;
            noteDTO.NoteId = Guid.NewGuid().ToString();
            noteDTO.UserIP = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(); 
            return Ok(this.noteRepository.AddNote(noteDTO));
        }


        [HttpGet]
        public IActionResult ListNotes()
        {
            var ip=  httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

            if (ip == null)
                return BadRequest();

            return Ok(this.noteRepository.ListNotes(ip));
        }
    }
}
