using CalculationServices.Contracts;
using CalculationServices.Helpers;
using CalculationServices.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationServices.Services.Base
{
    public class BaseProcessor
    {
        protected readonly Dictionary<string, List<(string destination, int distance)>> Chart;
        public BaseProcessor(IRouteChartRepository routeChartRepository, RouteDataValidator routeDataValidator, string filename)
        {
           
            // get routes from input file
            routeChartRepository.GenerateRouteChartFromInputFile(filename);
            Chart = routeChartRepository.GetChart();
            // validate data 
            var validationReslt = routeDataValidator.Validate(Chart);
            if (!validationReslt.IsValid)
            {
                Helper.ThrowValidationException(validationReslt);
            }
        }
    }
}
