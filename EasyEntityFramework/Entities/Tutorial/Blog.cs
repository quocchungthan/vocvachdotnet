using System;
using System.Collections.Generic;
using System.Text;

namespace EasyEntityFramework.Entities.Tutorial
{
    public class Blog
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
}
