using System;
using System.Linq;
using AutoMapper;
using EasyAppleNotes.ModuleNotes.DataLayer.Entities;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using MongoDB.Bson;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Mappers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateGetMapper<TagEntity, Tag>();
            CreateGetMapper<NoteEntity, Note>();

            CreateStoreMapper<Tag, TagEntity>();
            CreateStoreMapper<Note, NoteEntity>()
                .AfterMap((s, d) =>
                {
                    d.TagIds = s.Tags?.Select(x => new ObjectId(x.Id));
                });
        }

        private IMappingExpression<TSource, TDestination>  CreateStoreMapper<TSource, TDestination>()
            where TSource : BaseModel
            where TDestination : BaseEntity
        {
            return CreateMap<TSource, TDestination>().GenerateSystemFieldsForStoring();
        }

        private IMappingExpression<TSource, TDestination> CreateGetMapper<TSource, TDestination>()
            where TDestination : BaseModel
            where TSource: BaseEntity
        {
            return CreateMap<TSource, TDestination>();
        }

    }
}
