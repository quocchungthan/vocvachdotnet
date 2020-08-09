using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        public BaseEntity()
        {
        }
    }
}
