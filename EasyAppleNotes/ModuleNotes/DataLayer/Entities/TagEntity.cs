using System;
namespace EasyAppleNotes.ModuleNotes.DataLayer.Entities
{
    public class TagEntity: BaseEntity
    {
        String Name { get; set; }
        String Color { get; set; }

        public TagEntity()
        {
        }
    }
}
