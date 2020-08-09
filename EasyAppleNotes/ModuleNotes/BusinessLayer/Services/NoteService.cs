using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;

namespace EasyAppleNotes.ModuleNotes.BusinessLayer.Services
{
    public class NoteService: INoteService
    {
        public NoteService()
        {
        }

        public Task<IEnumerable<Note>> GetNotes()
        {
            throw new NotImplementedException();
        }
    }
}
