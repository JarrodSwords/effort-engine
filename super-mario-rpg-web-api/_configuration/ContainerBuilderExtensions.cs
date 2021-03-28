using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Effort.Domain;
using SuperMarioRpg.Application;

namespace SuperMarioRpg.WebApi
{
    public static class ContainerBuilderExtensions
    {
        private static readonly List<Assembly> Assemblies = new()
        {
            typeof(Entity).Assembly,
            typeof(FetchCharacters).Assembly,
            typeof(ContainerBuilderExtensions).Assembly
        };

        #region Public Interface

        public static void RegisterModules(this ContainerBuilder builder)
        {
            foreach (var assembly in Assemblies)
                builder.RegisterAssemblyModules(assembly);
        }

        #endregion
    }
}
