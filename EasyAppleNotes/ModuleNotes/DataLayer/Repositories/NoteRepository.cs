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
