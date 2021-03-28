using Autofac;

namespace Effort.Domain
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceProviderDispatcher>().As<IDispatcher>();
        }

        #endregion
    }
}
