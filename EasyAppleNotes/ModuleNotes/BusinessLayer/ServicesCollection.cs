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
            /**
            can use this to resolve the scoped service issue aswell
            using (var scope = _serviceProvider.CreateScope()) {
                var _emailRepository = scope.ServiceProvider.GetRequiredService<IEmailRepository>();

                //do your stuff....
            }
            **/
            services.AddSingleton<INoteService, NoteService>();
        }
    }
}
