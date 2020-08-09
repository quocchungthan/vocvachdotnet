using System;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Repositories;
using Xunit;

namespace AppleEasyNotesTests.DataLayer
{

    public class NoteRepositoryTests
    {
        public readonly INoteRepository _noteRepository;

        public NoteRepositoryTests()
        {
            _noteRepository = new NoteRepository();
        }

        [Fact]
        public void Should_Throw_Not_Implemented_Exception_Because_Method_Not_Implemented()
        {
            Assert.ThrowsAsync<NotImplementedException>(async () =>
            {
                await _noteRepository.GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex();
            });
        }
    }
}
