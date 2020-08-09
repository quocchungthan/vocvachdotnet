using System;
using System.Linq;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.DataLayer;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Repositories;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using Moq;
using Xunit;

namespace AppleEasyNotesTests.DataLayer
{

    public class NoteRepositoryTests : RepositoryTestsBase, IAsyncLifetime
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
            Assert.Single(result);
        }

        protected override async Task DropTempDb()
        {
            //throw new NotImplementedException();
            await _sut.DropDatabase();
        }

        protected override async Task PrepareDb()
        {
            //throw new NotImplementedException();
            var tagId = await _sut.Store(new Tag()
            {
                Name = "tag1",
                Color = "color1"
            });

            await _sut.Store(new Note()
            {
                Tags = new[] { new Tag() { Id = tagId } },
                Title = "title 1",
                Content = "content 1",
                IssueDate = new DateTime().ToUniversalTime(),
                OrderIndex = 0
            });
        }
    }
}
