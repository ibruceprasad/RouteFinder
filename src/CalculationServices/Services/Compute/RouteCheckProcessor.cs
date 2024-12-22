using CalculationServices.Contracts;
using CalculationServices.Services.Base;
using CalculationServices.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationServices.Services.Compute
{
    public class RouteCheckProcessor : BaseProcessor
    {
        public RouteCheckProcessor(IRouteChartRepository routeChartRepository, RouteDataValidator routeDataValidator, string filename)
            : base(routeChartRepository, routeDataValidator, filename)
        {
        }

        public bool IsRouteExists(List<string> route)
        {
            bool routeExists = false;
            for (int index = 0; index <= route.Count - 1; index++)
            {
                if (index + 1 == route.Count) return routeExists;

                var neighbours = Chart[route[index]];
                var nextStation = neighbours.FirstOrDefault(x => x.destination.Equals(route[index + 1]));
                if (nextStation == default)
                {
                    return false;
                }
                routeExists = true;
            }
            return routeExists;
        }


    }
}
