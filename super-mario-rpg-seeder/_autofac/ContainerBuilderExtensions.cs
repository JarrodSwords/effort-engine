using System.Collections.Generic;
using System.Reflection;
using Autofac;
using SuperMarioRpg.Application.Read;
using SuperMarioRpg.Application.Write.Characters.Enemies;
using SuperMarioRpg.Infrastructure.Write;
using Entity = Effort.Domain.Entity;

namespace SuperMarioRpg.Seeder
{
    public static class ContainerBuilderExtensions
    {
        private static readonly List<Assembly> Assemblies = new()
        {
            typeof(Entity).Assembly,
            typeof(FetchCharacters).Assembly,
            typeof(Create).Assembly,
            typeof(Context).Assembly,
            typeof(ContainerBuilderExtensions).Assembly
        };

        #region Static Interface

        public static ContainerBuilder RegisterModules(this ContainerBuilder builder)
        {
            foreach (var assembly in Assemblies)
                builder.RegisterAssemblyModules(assembly);

            builder.RegisterType<Seeder>();

            return builder;
        }

        #endregion
    }
}
