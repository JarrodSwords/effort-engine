using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Effort.Domain.Messages;

namespace SuperMarioRpg.Application.Write
{
    public static class ContainerBuilderExtensions
    {
        private static readonly Assembly Assembly = typeof(ContainerBuilderExtensions).Assembly;

        #region Static Interface

        private static bool IsHandler(Type type)
        {
            if (!type.IsGenericType)
                return false;

            var typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
        }

        public static ContainerBuilder RegisterCommandDecorators(this ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(
                typeof(CommandLogger<>),
                typeof(ICommandHandler<>),
                x => x.ImplementationType.IsDefined(typeof(LogAttribute))
            );

            return builder;
        }

        public static ContainerBuilder RegisterHandlers(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly)
                .Where(x => x.GetInterfaces().Any(IsHandler))
                .Where(x => x.Name.EndsWith("Handler"))
                .AsImplementedInterfaces();

            return builder;
        }

        #endregion
    }
}
