using Effort.Domain.Messages;
using Microsoft.AspNetCore.Builder;
using SuperMarioRpg.Application.Write;
using SuperMarioRpg.Application.Write.Enemies;
using SuperMarioRpg.Infrastructure.Write;

namespace SuperMarioRpg.WebApi
{
    public static class ApplicationBuilderExtensions
    {
        #region Public Interface

        public static IApplicationBuilder ConfigureDevDatabase(this IApplicationBuilder app)
        {
            var context = app.GetService<Context>();

            //if (context.Database.CanConnect() && context.IsLatest)
            //    return app;

            context.ApplyMigrations();

            app.GetService<ICommandHandler<Seed>>().Handle(new Seed());
            app.GetService<ICommandHandler<Application.Write.NonPlayerCharacters.Seed>>()
                .Handle(new Application.Write.NonPlayerCharacters.Seed());
            app.GetService<ICommandHandler<SeedPlayableCharacters>>().Handle(new SeedPlayableCharacters());

            return app;
        }

        public static T GetService<T>(this IApplicationBuilder app) where T : class
        {
            return app.ApplicationServices.GetService(typeof(T)) as T;
        }

        #endregion
    }
}
