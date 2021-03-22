using System;
using System.Linq;
using Effort.Domain;
using Microsoft.Extensions.DependencyInjection;
using SuperMarioRpg.Application;

namespace SuperMarioRpg.WebApi
{
    public static class ServiceCollectionExtensions
    {
        #region Public Interface

        public static void RegisterHandlers(this IServiceCollection services)
        {
            var handlerTypes = typeof(CreateCharacter).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(IsHandlerInterface))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (var type in handlerTypes)
                services.Add(type);
        }

        #endregion

        #region Private Interface

        private static void Add(this IServiceCollection services, Type type)
        {
            var interfaceType = type.GetInterfaces().Single(IsHandlerInterface);
            services.AddTransient(interfaceType, type);
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;

            var typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
        }

        #endregion
    }
}
