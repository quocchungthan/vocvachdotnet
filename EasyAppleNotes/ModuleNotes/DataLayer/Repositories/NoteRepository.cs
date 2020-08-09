using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Entities;
using MongoDB.Driver;
using System.Linq;
using Tag = EasyAppleNotes.ModuleNotes.EasyAppleCommonModel.Tag;
using AutoMapper;
using MongoDB.Bson;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Repositories
{
    public class NoteRepository: BaseRepository, INoteRepository
    {
        private readonly IMongoCollection<NoteEntity> _notes;
        private readonly IMongoCollection<TagEntity> _tags;

        public NoteRepository(INotestoreDatabaseSettings settings, IMapper mapper)
            : base(settings)
        {
            _mapper = mapper;
            _notes = _database.GetCollection<NoteEntity>(settings.CollectionNameNotes);
            _tags = _database.GetCollection<TagEntity>(settings.CollectionNameTags);
        }
        // TODO: Move this method to base and integrate MAPPERS
        public async Task<string> Store(Note note)
        {
            var dto = _mapper.Map<NoteEntity>(note);
            dto.TagIds = note.Tags.Select(x => new ObjectId(x.Id));

            await _notes.InsertOneAsync(dto);

            return dto.Id;
        }

        public async Task<string> Store(Tag tag)
        {
            var dto = _mapper.Map<TagEntity>(tag);

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
            var tagModels = tags.Select(_mapper.Map<Tag>);

            return notes.Select(x =>
            {
                var note = _mapper.Map<Note>(x);

                note.Tags = x.TagIds.Select(y => tagModels.First(z => y.ToString() == z.Id));

                return note;
            });
        }
    }
}
