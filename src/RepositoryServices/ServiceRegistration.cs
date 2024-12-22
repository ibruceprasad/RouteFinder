using CalculationServices.Contracts;
using Microsoft.Extensions.DependencyInjection;
using RepositoryServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryServices
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositoryServicesRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IRouteChartRepository, RouteChartRepository>();
            return services;
        }

    }
}
