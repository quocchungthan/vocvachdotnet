using System;
using System.Collections.Generic;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Entities
{
    public class NoteEntity: BaseEntity
    {
        DateTime IssueDate { get; set; }
        IEnumerable<TagEntity> Tags { get; set; }
        String Title { get; set; }
        String Content { get; set; }
        int OrderIndex { get; set; }

        public NoteEntity()
        {
        }
    }
}
