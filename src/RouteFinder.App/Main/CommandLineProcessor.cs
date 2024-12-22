using CalculationServices.Services.Base;
using Microsoft.Extensions.DependencyInjection;


namespace RouteFinder.App.Main
{
    public class CommandLineProcessor
    {
        private static string _filename = default!;
        private static string[] _args = default!;
        private static ICalculatorFactory _calculatorFactory = default!;

        public CommandLineProcessor(string[] args, string filename, ServiceProvider serviceProvider)
        {
            _args = args;
            _filename = filename;
            _calculatorFactory = serviceProvider.GetRequiredService<ICalculatorFactory>();
        }

        public void Run()
        {
            var serviceRequest = _args[0];
     
            switch (serviceRequest)
            {
                case "--max-stops":
                    Handler.GetAllTriptsWithMaxStops( _args,  _calculatorFactory);
                    break;

                case "--exact-stops":
                    Handler.GetAllTriptsWithExactStops(_args, _calculatorFactory);
                    break;

                case "--route-distance":
                    Handler.GetRouteDistance(_args, _calculatorFactory);
                    break;

                case "--route-exists":
                    Handler.IsRouteExists(_args, _calculatorFactory);
                    break;

                case "--max-distance":
                    Handler.GetAllTriptsWithMaxDistance(_args, _calculatorFactory);
                    break;

                case "--shortest-route":
                    Handler.GetShortestRoute(_args, _calculatorFactory);
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }


        }

    }
}
