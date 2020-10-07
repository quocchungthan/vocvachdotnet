using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EasyAppleNotesRestApi.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppleNotesRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController: ControllerBase
    {
        public FileController()
        {
        }
        /**
         * SECOND APPROACH:
         * provide a REST endpoint to upload files
         * TODO: Security considerations
         * TODO: performance comparations
         */
        [HttpPost]
        public Task Store([FromBody]List<FormFileInput> inputs)
        {
            return Task.CompletedTask;
        }

        [HttpGet]
        [Route("api/file/{id}")]
        public HttpResponseMessage DownloadFile([FromRoute]string fileId)
        {
            var path = @"C:\Temp\test.exe";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
    }
}
