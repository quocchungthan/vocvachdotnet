using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace EasyAppleNotes.ModuleNotes.DataLayer
{
    public class BaseRepository
    {
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _database;
        private readonly INotestoreDatabaseSettings _settings;

        public BaseRepository(INotestoreDatabaseSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
            _settings = settings;
        }

        public async Task DropDatabase()
        {
            await _client.DropDatabaseAsync(_settings.DatabaseName);
        }
    }
}
