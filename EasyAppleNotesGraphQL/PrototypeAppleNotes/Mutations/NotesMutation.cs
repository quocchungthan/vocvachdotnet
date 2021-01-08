using System;
using EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleNotes.EasyAppleCommonModel;
using GraphQL;
using GraphQL.Types;

namespace EasyAppleNotesGraphQL.PrototypeAppleNotes.Mutations
{
    public class NotesMutation : ObjectGraphType
    {
        public NotesMutation(IServiceProvider provider)
        {
            INoteService noteService = (INoteService)provider.GetService(typeof(INoteService));

            Name = nameof(NotesMutation);
            FieldAsync<StringGraphType>(
              "storeNote",
              arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "content" }
              ),
              resolve: async context =>
              {
                  var content = context.GetArgument<string>("content");
                  var r = new Random();
                  var id = "id_random_" + Math.Round(r.NextDouble() * 10000);
                  var model = new Note()
                  {
                      Id = id,
                      Content = content
                  };

                  var savedId = await noteService.StoreNote(model);

                  return savedId;
              },
              description: "Description should be define clearly including example"
            );
        }
    }
}
