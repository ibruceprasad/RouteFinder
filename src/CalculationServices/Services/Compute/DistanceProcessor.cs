using CalculationServices.Contracts;
using CalculationServices.Services.Base;
using CalculationServices.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalculationServices.Services.Compute
{
    public class DistanceProcessor : BaseProcessor
    {
        public DistanceProcessor(IRouteChartRepository routeChartRepository, RouteDataValidator routeDataValidator, string filename)
        : base(routeChartRepository, routeDataValidator, filename)
        {
        }

        public int? FindRouteDistance(List<string> route)
        {
            int? distance = null;

            for (int index = 0; index <= route.Count - 1; index++)
            {
                if (index + 1 == route.Count) return distance;

                var neighbours = Chart[route[index]];
                var nextStation = neighbours.FirstOrDefault(x => x.destination.Equals(route[index + 1]));
                if (nextStation == default)
                {
                    return null;
                }
                distance = distance ?? 0;
                distance = distance + nextStation.distance;
            }
            return distance;
        }
    }
}
