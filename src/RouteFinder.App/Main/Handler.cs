using CalculationServices.Services.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinder.App.Main
{
    public static class Handler
    {
        private static bool IsValidNumber(string input) => double.TryParse(input, out _);

        public static void GetAllTriptsWithMaxStops(string[] args, ICalculatorFactory calculatorFactory)
        {

            if ((args.Length !=5)) 
            {
                throw new ApplicationException("Invalid command arguments"); 
            } 
            
            var tripStartStation = args[1];
            var tripEndStation = args[2];
            var tripsWithMaxNoOfStops = args[3];
            var filename = args[4];

            var maxStopsCalculator = calculatorFactory.GetMaxStopsCalculator(filename);
            var result = maxStopsCalculator
                .FindAllTriptsWithMaxStops(tripStartStation, tripEndStation, Convert.ToInt16(tripsWithMaxNoOfStops));
            
            Console.WriteLine($"Results:");
            foreach (var r in result)
            {
                var route = string.Join("=>", r);
                Console.WriteLine(route);
            }
            
        }

        public static void GetAllTriptsWithExactStops(string[] args, ICalculatorFactory calculatorFactory)
        {
            if ((args.Length != 5))
            {
                throw new ApplicationException("Invalid command arguments");
            }

            var tripStartStation = args[1];
            var tripEndStation = args[2];
            var tripsWithExactNoOfStops = args[3];
            var filename = args[4];

            var exactStopsCalculator = calculatorFactory.GetExactStopsCalculator(filename);
            var result = exactStopsCalculator
                .FindAllTriptsWithExactStops(tripStartStation, tripEndStation, Convert.ToInt16(tripsWithExactNoOfStops));

            Console.WriteLine($"Results:");
            foreach (var r in result)
            {
                var route = string.Join("=>", r);
                Console.WriteLine(route);
            }

        }

        public static void GetAllTriptsWithMaxDistance(string[] args, ICalculatorFactory calculatorFactory)
        {
            if ((args.Length != 5))
            {
                throw new ApplicationException("Invalid command arguments");
            }

            var tripStartStation = args[1];
            var tripEndStation = args[2];
            var tripsWithMaxDistance = args[3];
            var filename = args[4];

            var exactStopsCalculator = calculatorFactory.GetMaxDistanceCalculator(filename);
            var result = exactStopsCalculator
                .FindAllTriptsWithMaxDistance(tripStartStation, tripEndStation, Convert.ToInt16(tripsWithMaxDistance));

            Console.WriteLine($"Results:");
            foreach (var r in result)
            {
                var route = string.Join("=>", r);
                Console.WriteLine(route);
            }
        }


        
        public static void GetRouteDistance(string[] args, ICalculatorFactory calculatorFactory)
        {
            if ((args.Length != 3))
            {
                throw new ApplicationException("Invalid command arguments");
            }
            var path = args[1];
            var filename = args[2];
            var route = path.Split(",");

            var distanceCalculator = calculatorFactory.GetDistanceComputeCalculator(filename);
            var result = distanceCalculator.FindRouteDistance(route.ToList());
            
            var message = result == null ? "Invalid input path given" : result.ToString();
            Console.WriteLine($"Results: {message}");
        }

        public static void IsRouteExists(string[] args, ICalculatorFactory calculatorFactory)
        {
            if ((args.Length != 3))
            {
                throw new ApplicationException("Invalid command arguments");
            }
            var path = args[1];
            var filename = args[2];
            var route = path.Split(",");

            var routeExistsCalculator = calculatorFactory.GetRouteCheckCalculator(filename);
            var result = routeExistsCalculator.IsRouteExists(route.ToList());

            var message = result == true ? "The route exits" : "The route doesn't exists";
            Console.WriteLine($"Results: {message}");
        }



        public static void GetShortestRoute(string[] args, ICalculatorFactory calculatorFactory)
        {
            if ((args.Length != 4))
            {
                throw new ApplicationException("Invalid command arguments");
            }

            var tripStartStation = args[1];
            var tripEndStation = args[2];
            var filename = args[3];

            var shortestDistanceCalculator = calculatorFactory.GetShortestDistanceCalculator(filename);
            var result = shortestDistanceCalculator.GetShortestRoute(tripStartStation, tripEndStation);
            var shortestRoute = string.Join("=>", result);
            Console.WriteLine($"Results: {shortestRoute}");

        }
  


    }
}
