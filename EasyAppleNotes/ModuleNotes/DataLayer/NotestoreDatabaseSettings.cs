using System;
namespace EasyAppleNotes.ModuleNotes.DataLayer
{
    public class NotestoreDatabaseSettings : INotestoreDatabaseSettings
    {
        public string ConnectionString { get;  set; }
        public string DatabaseName { get; set; }
    }

    public interface INotestoreDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
