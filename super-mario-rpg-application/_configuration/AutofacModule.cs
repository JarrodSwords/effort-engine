using Autofac;

namespace SuperMarioRpg.Application
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterHandlers()
                .RegisterCommandDecorators();
        }

        #endregion
    }
}
