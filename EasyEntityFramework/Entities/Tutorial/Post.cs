using System;
using System.Collections.Generic;
using System.Text;

namespace EasyEntityFramework.Entities.Tutorial
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid BlogId { get; set; }
    }
}
