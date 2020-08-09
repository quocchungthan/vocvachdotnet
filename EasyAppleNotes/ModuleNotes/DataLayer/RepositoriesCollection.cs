using System;
using EasyAppleNotes.ModuleNotes.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.DataLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EasyAppleNotes.ModuleNotes.DataLayer
{
    public static class RepositoriesCollection
    {
        public static void AddRepositoryDependency(this IServiceCollection repo)
        {
            repo.AddScoped<INoteRepository, NoteRepository>();
        }

        public static void SetupDatabaseSettings(this IServiceCollection services, IConfiguration config)
        {
            // requires using Microsoft.Extensions.Options
            services.Configure<NotestoreDatabaseSettings>(
                config.GetSection(nameof(NotestoreDatabaseSettings)));

            services.AddSingleton<INotestoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<NotestoreDatabaseSettings>>().Value);
        }
    }
}
