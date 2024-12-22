using Microsoft.Extensions.DependencyInjection;
using RepositoryServices;
using CalculationServices;
using FluentValidation;
using CalculationServices.Services.Validation;
using RouteFinder.App.Main;
using RouteFinder.App.Helpers;

var inputFilename = "";

try
{
    var services = new ServiceCollection();

    // registration of services
    var serviceProvider = services
        // reporsitory servicew
        .AddRepositoryServicesRegistration()
        // calclation services
        .AddCalculationServicesRegistration(inputFilename)
        // validation services
        .AddValidatorsFromAssemblyContaining<RouteDataValidator>()
        .BuildServiceProvider();

    var processor = new CommandLineProcessor(args, inputFilename, serviceProvider);
    
    processor.Run();

}
catch (ValidationException ex)
{
    ErrorResponseSender.PrintValidationErrors(ex.Message);
}
catch (ApplicationException ex)
{
    ErrorResponseSender.PrintApplicationErrors(ex.Message);
}
catch (Exception ex)
{
    ErrorResponseSender.PrintUnknownErrors(ex.Message);
}







 