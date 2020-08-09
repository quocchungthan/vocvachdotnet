using System;
using MongoDB.Driver;

namespace EasyAppleNotes.ModuleNotes.DataLayer
{
    public class BaseRepository
    {
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _database;

        public BaseRepository(INotestoreDatabaseSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
        }
    }
}
