using System;
using AutoMapper;
using EasyAppleNotes.ModuleAuthorization.BusinessLayer;
using EasyAppleNotes.ModuleAuthorization.DataLayer.EasyAppleRepositories;
using EasyAppleNotes.ModuleNotes.BusinessLayer;
using EasyAppleNotes.ModuleNotes.DataLayer;
using EasyAppleNotes.ModuleNotes.DataLayer.Mappers;
using EasyAppleNotesGraphQL.Collector;
using EasyAppleNotesGraphQL.Schemas;
using EasyHttpClients.Auth0Client;
using EasyHttpClients.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

// Each Customer has their own RestProject, and every other projects is common for all customer
namespace EasyAppleNotesRestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.CollectQuery();

            /**
             * Integerate httpClient & EF dependencies
             */
            // The Mapper profile should be in Data projects
            services.AddAutoMapper(c => c.AddProfile<MapperProfile>(), typeof(Startup));
            services.SetupDatabaseSettings(Configuration);
            // requires using Microsoft.Extensions.Options
            services.Configure<AuthClientSetting>(
                Configuration.GetSection(nameof(AuthClientSetting)));
            services.AddSingleton<IAuth0ClientSetting>(sp =>
                sp.GetRequiredService<IOptions<AuthClientSetting>>().Value);
            // must be registered after configuration
            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();
            /**
             * End
             */
            services.AddRepositoryDependency();
            services.AddAuthServiceDependency();
            services.AddServiceDependency();

            // -- Workaround: temperary allow SynchronousIO
            // kestrel
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // IIS
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthorizationMiddleware();
            app.UseGraphQL<EasyAppleNotesSchema>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
