using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Effort.Domain;

namespace SuperMarioRpg.Application
{
    public static class AutofacExtensions
    {
        #region Public Interface

        public static Type GetHandlerInterface(this Type type)
        {
            return type.GetInterfaces().Single(IsHandler);
        }

        /// <summary>
        ///     Gets <see cref="ICommandHandler{T}" /> and <see cref="IQueryHandler{TQuery,TResult}" /> types excluding decorators.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetHandlers(this Assembly assembly)
        {
            return assembly == null
                ? new List<Type>()
                : assembly.GetTypes()
                    .Where(x => x.GetInterfaces().Any(IsHandler))
                    .Where(x => x.Name.EndsWith("Handler"));
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

        #endregion
    }
}
