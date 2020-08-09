using System;
namespace EasyAppleNotes.ModuleNotes.EasyAppleCommonModel
{
    public class BaseModel
    {
        public String Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseModel()
        {
        }
    }
}
