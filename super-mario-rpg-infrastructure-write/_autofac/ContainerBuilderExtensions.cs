﻿using System.Reflection;
using Autofac;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Infrastructure.Write
{
    public static class ContainerBuilderExtensions
    {
        private static readonly Assembly Assembly = typeof(ContainerBuilderExtensions).Assembly;

        #region Static Interface

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

        public static ContainerBuilder RegisterUnitOfWork(this ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            return builder;
        }

        #endregion
    }
}