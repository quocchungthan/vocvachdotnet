using System;
using System.Collections.Generic;

namespace EasyAppleNotes.ModuleNotes.EasyAppleCommonModel
{
    public class Note: BaseModel
    {

        DateTime IssueDate { get; set; }
        IEnumerable<Tag> Tags { get; set; }
        String Title { get; set; }
        String Content { get; set; }
        int OrderIndex { get; set; }


        public Note()
        {
        }
    }
}
