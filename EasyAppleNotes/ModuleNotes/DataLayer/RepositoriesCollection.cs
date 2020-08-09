using System;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAppleNotes.ModuleNotes.DataLayer
{
    public static class RepositoriesCollection
    {
        public static void AddRepositoryDependency(this IServiceCollection repo)
        {
            repo.AddScoped<INoteRepository, NoteRepository>();
        }
    }
}
