using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;

namespace EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex();
        Task<string> Store<Note>(Note note);
    }
}
