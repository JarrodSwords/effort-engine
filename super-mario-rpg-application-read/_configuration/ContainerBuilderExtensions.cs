using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Effort.Domain.Messages;

namespace SuperMarioRpg.Application.Read
{
    public static class ContainerBuilderExtensions
    {
        private static readonly Assembly Assembly = typeof(ContainerBuilderExtensions).Assembly;

        #region Static Interface

        private static bool IsHandler(Type type)
        {
            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == typeof(IQueryHandler<,>);
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
