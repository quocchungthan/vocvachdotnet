using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.CommonModel;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Repositories
{
    public class NoteRepository: BaseRepository, INoteRepository
    {
        public NoteRepository()
        {
        }

        public Task<IEnumerable<Note>> GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex()
        {
            throw new NotImplementedException();
        }
    }
}
