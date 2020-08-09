using System;
using System.Collections.Generic;
using System.Linq;
using EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleNotes.BusinessLayer.Services;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using Moq;
using Xunit;

namespace AppleEasyNotesTests.BusinessLayer
{
    public class NoteServiceTests
    {
        private readonly Mock<INoteRepository> _mockNoteRepo;
        private readonly INoteService _sut;

        public NoteServiceTests()
        {
            _mockNoteRepo = new Mock<INoteRepository>();
            _sut = new NoteService(_mockNoteRepo.Object);
        }

        [Fact]
        public void Should_Throw_Not_Implemented_Exception()
        {
            Assert.ThrowsAsync<NotImplementedException>(async () =>
            {
                await _sut.GetNotes();
            });
        }

        [Fact]
        public async void Should_Return_An_Empty_Array_If_Repository_Return_An_Empty_Array()
        {
            var expectedReturn = new List<Note>();
            _mockNoteRepo.Setup((x) => x.GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex())
                    .ReturnsAsync(expectedReturn);

            var result = await _sut.GetNotes();
            Assert.NotNull(result);
            Assert.Equal(result.Count(), expectedReturn.Count);
        }
    }
}
