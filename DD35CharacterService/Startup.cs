﻿using DD35CharacterService.ExceptionHandling;
using DD35CharacterService.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DD35CharacterService
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
            services.AddControllers(config => config.Filters.Add(typeof(GlobalExceptionFilter)));
            services.AddCors(o =>
            {
                o.AddPolicy("AnyOrigin", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AnyOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            new SqliteDBSetup("characters").CreateTables();
        }
    }
}
