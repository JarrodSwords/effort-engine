using System.Collections.Generic;
using System.Reflection;
using Autofac;
using SuperMarioRpg.Application.Read.Characters;
using SuperMarioRpg.Application.Write.NonPlayerCharacters;
using SuperMarioRpg.Infrastructure.Write;
using Entity = Effort.Domain.Entity;

namespace SuperMarioRpg.WebApi
{
    public static class ContainerBuilderExtensions
    {
        private static readonly List<Assembly> Assemblies = new()
        {
            typeof(Entity).Assembly,
            typeof(Fetch).Assembly,
            typeof(Create).Assembly,
            typeof(Context).Assembly,
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
