using System;
using EasyAppleNotesGraphQL.PrototypeAppleNotes.Types;
using EasyAppleNotesGraphQL.Schemas;
using EasyAppleNotesGraphQL.Types;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAppleNotesGraphQL.Collector
{
    public static class QueryCollectionExtension
    {
        public static void CollectQuery(this IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddScoped<IServiceProvider, DefaultServiceProvider>();
            services.AddTransient<NoteType>();
            services.AddTransient<SearchNoteType>();
            services.AddTransient<EasyAppleNotesSchema>();
        }
    }
}
