using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;

namespace EasyAppleNotes.ModuleNotes.BusinessLayer.Services
{
    public class NoteService: INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<IEnumerable<Note>> GetNotes()
        {
            return _noteRepository.GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex();
        }
    }
}
