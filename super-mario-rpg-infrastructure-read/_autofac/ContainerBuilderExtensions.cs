using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Effort.Domain.Messages;
using Microsoft.Extensions.Caching.Memory;

namespace SuperMarioRpg.Infrastructure.Read
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

        public static ContainerBuilder RegisterDecorators(this ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(
                typeof(CachingDecorator<,>),
                typeof(IQueryHandler<,>),
                x => x.ImplementationType.IsDefined(typeof(CachedAttribute))
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

        public static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();

            return builder;
        }

        #endregion
    }
}
