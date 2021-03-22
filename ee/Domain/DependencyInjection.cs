using Microsoft.Extensions.DependencyInjection;

namespace Effort.Domain
{
    public static class DependencyInjection
    {
        #region Public Interface

        public static IServiceCollection RegisterEffortServices(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher, ServiceProviderDispatcher>();
            return services;
        }

        #endregion
    }
}
