using System;
using System.Threading.Tasks;
using AutoMapper;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleDecorators;
using EasyAppleNotes.ModuleNotes.DataLayer.Entities;
using MongoDB.Driver;

namespace EasyAppleNotes.ModuleNotes.DataLayer
{
    public class BaseRepository<TEntity>
            where TEntity : BaseEntity
    {
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _database;
        private readonly INotestoreDatabaseSettings _settings;
        protected IMapper _mapper;

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


        protected IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(CollectionName.GetCollectionName(typeof(T)));
        }

        public Task<string> Store<TModel>(TModel note) => Store<TEntity, TModel>(note);

        public async Task<string> Store<TInput, TModel>(TModel note)
            where TInput : BaseEntity
        {
            var dto = _mapper.Map<TInput>(note);

            await GetCollection<TInput>().InsertOneAsync(dto);

            return dto.Id;
        }

    }
}
