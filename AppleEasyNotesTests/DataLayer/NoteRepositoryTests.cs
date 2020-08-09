using System;
using EasyAppleNotes.ModuleNotes.DataLayer;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Repositories;
using Moq;
using Xunit;

namespace AppleEasyNotesTests.DataLayer
{

    public class NoteRepositoryTests : RepositoryTestsBase
    {
        public readonly NoteRepository _sut;

        public NoteRepositoryTests():base()
        {
            _sut = new NoteRepository(_mockDbSetting.Object);
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
            var result = await _sut.GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex();

            Assert.NotNull(result);
        }

        protected override void DropTempDb()
        {
            //throw new NotImplementedException();
            _sut.DropDatabase();
        }

        protected override void PrepareDb()
        {
            //throw new NotImplementedException();
        }
    }
}
