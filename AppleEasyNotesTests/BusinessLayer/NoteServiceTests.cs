using System;
using EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleNotes.BusinessLayer.Services;
using Xunit;

namespace AppleEasyNotesTests.BusinessLayer
{
    public class NoteServiceTests
    {
        private readonly INoteService _sut;

        public NoteServiceTests()
        {
            _sut = new NoteService();
        }

        [Fact]
        public void Should_Throw_Not_Implemented_Exception()
        {
            Assert.ThrowsAsync<NotImplementedException>(async () =>
            {
                await _sut.GetNotes();
            });
        }
    }
}
