using System;
using System.Linq;
using Autofac;
using Effort.Domain;

namespace SuperMarioRpg.Application
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            RegisterHandlers(builder);
        }

        #endregion

        #region Private Interface

        private static bool IsHandler(Type type)
        {
            if (!type.IsGenericType)
                return false;

            var typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
        }

        private static void RegisterHandlers(ContainerBuilder builder)
        {
            var types = typeof(FetchCharacters).Assembly
                .GetTypes()
                .Where(x => x.GetInterfaces().Any(IsHandler))
                .Where(x => x.Name.EndsWith("Handler"));

            foreach (var type in types)
                builder.RegisterType(type).As(type.GetInterfaces().Single(IsHandler));
        }

        #endregion
    }
}
