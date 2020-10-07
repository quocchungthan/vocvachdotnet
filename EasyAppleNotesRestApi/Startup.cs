using System;
using AutoMapper;
using EasyAppleNotes.ModuleNotes.BusinessLayer;
using EasyAppleNotes.ModuleNotes.DataLayer;
using EasyAppleNotes.ModuleNotes.DataLayer.Mappers;
using EasyAppleNotesGraphQL.Collector;
using EasyAppleNotesGraphQL.Schemas;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddAutoMapper(c => c.AddProfile<MapperProfile>(), typeof(Startup));
            services.SetupDatabaseSettings(Configuration);
            services.AddRepositoryDependency();
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

            app.UseGraphQL<EasyAppleNotesSchema>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
