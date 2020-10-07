using System;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using GraphQL.Types;

namespace EasyAppleNotesGraphQL.Types
{
    public class NoteType: ObjectGraphType<Note>
    {
        public NoteType()
        {
            Name = nameof(NoteType);
            Field(x => x.Content).Description("Store anything you want");
            Field(x => x.Id).Description("Description should be define clearly including example: " + Guid.NewGuid().ToString());
        }
    }
}
