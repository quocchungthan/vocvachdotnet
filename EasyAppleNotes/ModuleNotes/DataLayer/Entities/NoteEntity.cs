using System;
using System.Collections.Generic;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleDecorators;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Entities
{
    [CollectionName("notes")]
    public class NoteEntity: BaseEntity
    {
        [BsonElement("issueDate")]
        public DateTime IssueDate { get; set; }
        [BsonElement("tags")]
        public IEnumerable<ObjectId> TagIds { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("content")]
        public string Content { get; set; }
        [BsonElement("orderIndex")]
        public int OrderIndex { get; set; }

        public NoteEntity()
        {
        }
    }
}
