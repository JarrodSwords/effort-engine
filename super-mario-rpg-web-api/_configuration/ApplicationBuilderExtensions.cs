using Effort.Domain.Messages;
using Microsoft.AspNetCore.Builder;
using SuperMarioRpg.Application.Write;
using SuperMarioRpg.Infrastructure.Write;

namespace SuperMarioRpg.WebApi
{
    public static class ApplicationBuilderExtensions
    {
        #region Public Interface

        public static IApplicationBuilder ConfigureDevDatabase(this IApplicationBuilder app)
        {
            app.GetService<Context>()?.ApplyMigrations();
            app.GetService<ICommandHandler<SeedNonPlayerCharacters>>().Handle(new SeedNonPlayerCharacters());

            return app;
        }

        public static T GetService<T>(this IApplicationBuilder app) where T : class
        {
            return app.ApplicationServices.GetService(typeof(T)) as T;
        }

        #endregion
    }
}