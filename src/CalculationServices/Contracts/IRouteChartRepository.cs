using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationServices.Contracts
{
    public interface IRouteChartRepository
    {
        void GenerateRouteChartFromInputFile(string fileName);
        Dictionary<string, List<(string destination, int distance)>> GetChart();
    }
}
