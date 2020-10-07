using System;
using EasyAppleNotesGraphQL.PrototypeAppleNotes.Types;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace EasyAppleNotesGraphQL.Schemas
{
    public class EasyAppleNotesSchema: Schema
    {
        public EasyAppleNotesSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<SearchNoteType>();
        }
    }
}
