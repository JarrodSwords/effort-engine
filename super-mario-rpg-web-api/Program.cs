using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SuperMarioRpg.Infrastructure.Write;

namespace SuperMarioRpg.WebApi
{
    public class Program
    {
        #region Public Interface

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);
            var host = builder.Build();

            host.Services.GetAutofacRoot().Resolve<Context>().Update();

            host.Run();
        }

        #endregion
    }
}
