using System.Collections.Generic;
using System.Reflection;
using Autofac;

namespace SuperMarioRpg.WebApi
{
    public static class AutofacExtensions
    {
        #region Public Interface

        public static void RegisterModules(this ContainerBuilder builder, IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
                builder.RegisterAssemblyModules(assembly);
        }

        #endregion
    }
}
