using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;

namespace EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<string> StoreNote(Note note);
    }
}
