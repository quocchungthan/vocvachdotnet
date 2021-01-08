using System;
using EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using EasyAppleNotesGraphQL.Types;
using GraphQL;
using GraphQL.Types;

namespace EasyAppleNotesGraphQL.PrototypeAppleNotes.Types
{
    public class SearchNoteType: ObjectGraphType
    {
        public SearchNoteType(INoteService noteService)
        {
            Name = nameof(SearchNoteType);
            Field<NoteType>(
              "note",
              arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "id" }
              ),
              resolve: context =>
              {
                  var id = context.GetArgument<string>("id");
                  return new Note()
                  {
                      Id = id,
                      Content = "Text xxx"
                  };
              },
              description: "Description should be define clearly including example"
            );

            Field<ListGraphType<NoteType>>(
              "notes",
              resolve: context =>
              {
                  return noteService.GetNotes();
              },
              description: "Description should be define clearly including example"
            );

        }
    }
}
