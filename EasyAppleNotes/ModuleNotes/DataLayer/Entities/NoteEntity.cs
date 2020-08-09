using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Entities
{
    public class NoteEntity: BaseEntity
    {
        [BsonElement("issueDate")]
        public DateTime IssueDate { get; set; }
        [BsonElement("tags")]
        public IEnumerable<ObjectId> TagIds { get; set; }
        [BsonElement("title")]
        public String Title { get; set; }
        [BsonElement("content")]
        public String Content { get; set; }
        [BsonElement("orderIndex")]
        public int OrderIndex { get; set; }

        public NoteEntity()
        {
        }
    }
}
