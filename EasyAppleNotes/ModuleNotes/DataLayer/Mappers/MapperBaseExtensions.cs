using System;
using AutoMapper;
using EasyAppleNotes.ModuleNotes.DataLayer.Entities;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using MongoDB.Bson;

namespace EasyAppleNotes.ModuleNotes.DataLayer.Mappers
{
    public static class MapperBaseExtensions
    {

        public static IMappingExpression<TSource, TDestination> GenerateSystemFieldsForStoring<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mapper)
            where TSource : BaseModel
            where TDestination : BaseEntity
        {
            return mapper.ForMember(x => x.CreatedAt, y => y.MapFrom(z => DateTime.UtcNow))
                .ForMember(x => x.UpdatedAt, y => y.MapFrom(z => DateTime.UtcNow))
                .ForMember(x => x.Id, y => y.MapFrom(z => ObjectId.GenerateNewId().ToString()));
        }
    }
}
