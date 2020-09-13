using System;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleDecorators;
using MongoDB.Bson.Serialization.Attributes;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Entities
{
    [CollectionName("tags")]
    public class TagEntity: BaseEntity
    {
        /// <summary>
        /// Default: 5f2fa8afca8dc9fac336db1f
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("color")]
        public string Color { get; set; }

        public TagEntity()
        {
        }
    }
}
