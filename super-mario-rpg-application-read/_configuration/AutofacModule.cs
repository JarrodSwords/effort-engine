using Autofac;

namespace SuperMarioRpg.Application.Read
{
    public class AutofacModule : Module
    {
        #region Protected Interface

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterHandlers();
        }

        #endregion
    }
}
