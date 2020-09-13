using System;
namespace EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleDecorators
{
    public class CollectionName: Attribute
    {
        private readonly string _collectionName;
        public CollectionName(string collectionName)
        {
            _collectionName = collectionName;
        }

        public static string GetCollectionName(Type t)
        {

            // Using reflection.  
            Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.  

            // Displaying output.  
            foreach (System.Attribute attr in attrs)
            {
                if (attr is CollectionName a)
                {
                    return a._collectionName;
                }
            }

            throw new NotImplementedException("Should define CollectionName in Entity model ex: [CollectionName(\"name\")]");
        }
    }
}
