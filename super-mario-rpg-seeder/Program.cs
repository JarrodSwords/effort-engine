using Autofac;

namespace SuperMarioRpg.Seeder
{
    internal class Program
    {
        private static IContainer _container;

        #region Static Interface

        private static void Main(string[] args)
        {
            _container = new ContainerBuilder()
                .RegisterModules()
                .Build();

            _container.Resolve<Seeder>()
                .ConfigureDevDatabase()
                .Seed();
        }

        #endregion
    }
}
