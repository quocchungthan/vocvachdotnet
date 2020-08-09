using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Entities;
using MongoDB.Driver;
using System.Collections;
using System.Linq;
using Tag = EasyAppleNotes.ModuleNotes.EasyAppleCommonModel.Tag;
using MongoDB.Bson;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Repositories
{
    public class NoteRepository: BaseRepository, INoteRepository
    {
        private readonly IMongoCollection<NoteEntity> _notes;
        private readonly IMongoCollection<TagEntity> _tags;

        public NoteRepository(INotestoreDatabaseSettings settings)
            : base(settings)
        {
            _notes = _database.GetCollection<NoteEntity>(settings.CollectionNameNotes);
            _tags = _database.GetCollection<TagEntity>(settings.CollectionNameTags);
        }
        // TODO: Move this method to base and integrate MAPPERS
        public async Task<string> Store(Note note)
        {
            var dto = new NoteEntity()
            {
                Id = new ObjectId().ToString(),
                CreatedAt = new DateTime().ToUniversalTime(),
                UpdatedAt = new DateTime().ToUniversalTime(),
                Title = note.Title,
                Content = note.Content,
                IssueDate = note.IssueDate,
                OrderIndex = note.OrderIndex,
                TagIds = note.Tags.Select(x => new ObjectId(x.Id))
            };

            await _notes.InsertOneAsync(dto);

            return dto.Id;
        }

        public async Task<string> Store(Tag tag)
        {
            var dto = new TagEntity()
            {
                Id = new ObjectId().ToString(),
                CreatedAt = new DateTime().ToUniversalTime(),
                UpdatedAt = new DateTime().ToUniversalTime(),
                Color = tag.Color,
                Name = tag.Name
            };

            await _tags.InsertOneAsync(dto);

            return dto.Id;
        }

        public async Task<IEnumerable<Note>> GetAllNotesOrderByIssueDayThenCreatedAtThenOrderIndex()
        {
            var result = await _notes.Find(note => true)
                    .SortByDescending(note => note.IssueDate)
                    .SortByDescending(note => note.CreatedAt)
                    .SortBy(note => note.OrderIndex)
                    .ToListAsync();

            var tagIds = result.Select(note => note.TagIds)
                    .SelectMany(x => x)
                    .Select(x => x.ToString());

            var tags = await _tags.Find(tag => tagIds.Contains(tag.Id))
                    .ToListAsync();

            return MapNotes(result, tags);
        }

        private IEnumerable<Note> MapNotes(IEnumerable<NoteEntity> notes, IEnumerable<TagEntity> tags)
        {
            var tagModels = tags.Select(x =>
            {
                return new Tag()
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Name = x.Name,
                    Color = x.Color,
                };
            });

            return notes.Select(x =>
            {
                return new Note()
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    Title = x.Title,
                    Content = x.Content,
                    IssueDate = x.IssueDate,
                    OrderIndex = x.OrderIndex,
                    Tags = x.TagIds.Select(y => tagModels.First(z => y.ToString() == z.Id))
                };
            });
        }
    }
}
