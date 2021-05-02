using Autofac;

namespace SuperMarioRpg.Infrastructure.Write
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterContext()
                .RegisterUnitOfWork();
        }

        #endregion
    }
}
