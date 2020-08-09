using System;
using MongoDB.Bson.Serialization.Attributes;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Entities
{
    public class TagEntity: BaseEntity
    {
        /// <summary>
        /// Default: 5f2fa8afca8dc9fac336db1f
        /// </summary>
        [BsonElement("name")]
        public String Name { get; set; }
        [BsonElement("color")]
        public String Color { get; set; }

        public TagEntity()
        {
        }
    }
}
