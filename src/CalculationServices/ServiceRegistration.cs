using CalculationServices.Contracts;
using CalculationServices.Services.Base;
using Microsoft.Extensions.DependencyInjection;


namespace CalculationServices
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCalculationServicesRegistration(this IServiceCollection services, string filename)
        {
            services.AddSingleton<ICalculatorFactory, CalculatorFactory>();
            return services;
        }
    }
}