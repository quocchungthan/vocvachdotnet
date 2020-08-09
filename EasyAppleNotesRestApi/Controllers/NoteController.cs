using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppleNotesRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController: ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public Task<IEnumerable<Note>> Index()
        {
            return _noteService.GetNotes();
        }
    }
}
