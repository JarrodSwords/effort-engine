using Autofac;

namespace SuperMarioRpg.Infrastructure.Read
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterServices()
                .RegisterHandlers()
                .RegisterDecorators();
        }

        #endregion
    }
}
