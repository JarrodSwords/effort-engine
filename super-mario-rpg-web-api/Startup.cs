using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Effort.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SuperMarioRpg.Application;

namespace SuperMarioRpg.WebApi
{
    public class Startup
    {
        private readonly List<Assembly> _assemblies = new()
        {
            typeof(Entity).Assembly,
            typeof(FetchCharacters).Assembly
        };

        #region Creation

        public Startup(IWebHostEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddEnvironmentVariables()
                .Build();
        }

        #endregion

        #region Public Interface

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SuperMarioRpg.WebApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapHealthChecks("/healthcheck");
                    endpoints.MapControllers();
                }
            );
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModules(_assemblies);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();
            services.AddSwaggerGen(
                c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "SuperMarioRpg.WebApi", Version = "v1" }); }
            );
        }

        #endregion
    }
}