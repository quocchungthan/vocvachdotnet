using System;
using System.Collections.Generic;

namespace EasyAppleNotes.ModuleNotes.EasyAppleCommonModel
{
    public class Note: BaseModel
    {

        public DateTime IssueDate { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public int OrderIndex { get; set; }


        public Note()
        {
        }
    }
}
