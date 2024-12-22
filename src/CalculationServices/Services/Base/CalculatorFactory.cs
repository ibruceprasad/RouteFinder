using CalculationServices.Contracts;
using CalculationServices.Services.Compute;
using CalculationServices.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationServices.Services.Base
{
    public interface ICalculatorFactory
    {
        MaxStopsProcessor GetMaxStopsCalculator(string filename);
        ExactStopsProcessor GetExactStopsCalculator(string filename);
        DistanceProcessor GetDistanceComputeCalculator(string filename);
        RouteCheckProcessor GetRouteCheckCalculator(string filename);
        MaxDistanceProcessor GetMaxDistanceCalculator(string filename);
        ShortestRouteProcessor GetShortestDistanceCalculator(string filename);
    }

    public class CalculatorFactory : ICalculatorFactory
    {
        private readonly IRouteChartRepository _routeChartRepository;
        private readonly RouteDataValidator _routeDataValidator;
        public CalculatorFactory(IRouteChartRepository routeChartRepository, RouteDataValidator routeDataValidator)
        {
            _routeChartRepository = routeChartRepository;
            _routeDataValidator = routeDataValidator;
        }
        public MaxStopsProcessor GetMaxStopsCalculator(string filename) => new MaxStopsProcessor(_routeChartRepository, _routeDataValidator, filename);
        public RouteCheckProcessor GetRouteCheckCalculator(string filename) => new RouteCheckProcessor(_routeChartRepository, _routeDataValidator, filename);
        public MaxDistanceProcessor GetMaxDistanceCalculator(string filename) => new MaxDistanceProcessor(_routeChartRepository, _routeDataValidator, filename);
        public ExactStopsProcessor GetExactStopsCalculator(string filename) => new ExactStopsProcessor(_routeChartRepository, _routeDataValidator, filename);
        public DistanceProcessor GetDistanceComputeCalculator(string filename) => new DistanceProcessor(_routeChartRepository, _routeDataValidator, filename);
        public ShortestRouteProcessor GetShortestDistanceCalculator(string filename) => new ShortestRouteProcessor(_routeChartRepository, _routeDataValidator, filename);
    }
}
