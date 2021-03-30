using Autofac;

namespace SuperMarioRpg.Postgresql
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
