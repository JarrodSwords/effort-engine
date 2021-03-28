using System.Reflection;
using Autofac;
using Effort.Domain;
using Module = Autofac.Module;

namespace SuperMarioRpg.Application
{
    public class AutofacModule : Module
    {
        private static readonly Assembly Assembly = typeof(AutofacModule).Assembly;

        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            RegisterHandlers(builder);
        }

        #endregion

        #region Private Interface

        private static void RegisterHandlers(ContainerBuilder builder)
        {
            foreach (var handler in Assembly.GetHandlers())
                builder.RegisterType(handler).As(handler.GetHandlerInterface());

            builder.RegisterGenericDecorator(
                typeof(LoggerDecorator<>),
                typeof(ICommandHandler<>),
                x => x.ImplementationType.IsDefined(typeof(Logged))
            );
        }

        #endregion
    }
}
