using System;
using Microsoft.AspNetCore.Http;

namespace EasyAppleNotesRestApi.Input
{
    public interface FormFileInput
    {
        //public IFormFile File { get; set; }
        public Guid Id { get; set; }
        public byte[] FileContent { get; set; }
    }
}
