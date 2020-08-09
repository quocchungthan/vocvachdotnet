using System;
using EasyAppleNotes.ModuleNotes.DataLayer;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Repositories;
using Moq;
using Xunit;

namespace AppleEasyNotesTests.DataLayer
{

    public class NoteRepositoryTests:RepositoryTestsBase
    {
        public readonly INoteRepository _noteRepository;

        public NoteRepositoryTests():base()
        {
            _noteRepository = new NoteRepository(_mockDbSetting.Object);
        }

        //[Fact]
        //public void Should_Throw_Not_Implemented_Exception_Because_Method_Not_Implemented()
        //{
        //    Assert.ThrowsAsync<NotImplementedException>(async () =>
        //    {
        //        await _noteRepository.GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex();
        //    });
        //}

        [Fact]
        public async void Should_Not_Throw_Not_Implemented_Exception()
        {
            var result = await _noteRepository.GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex();

            Assert.NotNull(result);
        }
    }
}
