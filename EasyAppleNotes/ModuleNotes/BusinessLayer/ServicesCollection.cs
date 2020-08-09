using System;
using EasyAppleNotes.ModuleNotes.BusinessLayer.EasyAppleServices;
using EasyAppleNotes.ModuleNotes.BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAppleNotes.ModuleNotes.BusinessLayer
{
    public static class ServicesCollection
    {
        // extension method for IServiceCollection objects
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
        }
    }
}
