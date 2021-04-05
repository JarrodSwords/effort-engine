using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SuperMarioRpg.Infrastructure.Write;

namespace SuperMarioRpg.WebApi
{
    public class Startup
    {
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

            UpdateContext(app);

            if (env.IsDevelopment())
                SeedData(app);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<Context>();
            builder.RegisterModules();
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

        public static void SeedData(IApplicationBuilder app)
        {
            //var context = app.ApplicationServices.GetService(typeof(Context)) as Context;
            //context?.Update();
        }

        public static void UpdateContext(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService(typeof(Context)) as Context;
            context?.Update();
        }

        #endregion
    }
}