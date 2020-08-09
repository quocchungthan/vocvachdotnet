using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyAppleNotes.ModuleNotes.DataLayer;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Entities;
using EasyAppleNotes.ModuleNotes.DataLayer.Repositories;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace AppleEasyNotesTests.DataLayer
{

    public class NoteRepositoryTests : RepositoryTestsBase, IAsyncLifetime
    {
        private readonly Mock<IMapper> _mockMapper;
        public readonly NoteRepository _sut;

        public NoteRepositoryTests():base()
        {
            _mockMapper = new Mock<IMapper>();
            _sut = new NoteRepository(_mockDbSetting.Object, _mockMapper.Object);
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
            var expectedStoredTag = new Tag()
            {
                Id = ObjectId.GenerateNewId().ToString()
            };

            var expectedStoredNote = new Note()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Tags = new[] { new Tag { Id = expectedStoredTag.Id } }
            };

            _mockMapper.Setup(x => x.Map<Note>(It.IsNotNull<NoteEntity>()))
                .Returns(expectedStoredNote);
            _mockMapper.Setup(x => x.Map<Tag>(It.IsNotNull<TagEntity>()))
                .Returns(expectedStoredTag);

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

            var expectedStoredTag = new TagEntity()
            {
                Id = ObjectId.GenerateNewId().ToString()
            };

            var expectedStoredNote = new NoteEntity()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                TagIds = new[] { new ObjectId(expectedStoredTag.Id) }
            };

            _mockMapper.Setup(x => x.Map<NoteEntity>(It.IsNotNull<Note>()))
                .Returns(expectedStoredNote);
            _mockMapper.Setup(x => x.Map<TagEntity>(It.IsNotNull<Tag>()))
                .Returns(expectedStoredTag);

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
