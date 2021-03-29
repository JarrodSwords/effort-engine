using System.Reflection;
using Autofac;

namespace SuperMarioRpg.Postgres
{
    public static class ContainerBuilderExtensions
    {
        private static readonly Assembly Assembly = typeof(ContainerBuilderExtensions).Assembly;

        #region Public Interface

        public static ContainerBuilder RegisterContext(this ContainerBuilder builder)
        {
            builder.RegisterType<Context>();
            return builder;
        }

        public static ContainerBuilder RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            return builder;
        }

        #endregion
    }
}
