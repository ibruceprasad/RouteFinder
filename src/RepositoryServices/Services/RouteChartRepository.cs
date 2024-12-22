using CalculationServices.Contracts;
using RouteService.Models;

namespace RepositoryServices.Services
{

    public class RouteChartRepository : IRouteChartRepository
    {
        private Dictionary<string, List<(string destination, int distance)>> Chart = new Dictionary<string, List<(string, int)>>();
        public RouteChartRepository() { }

        public void GenerateRouteChartFromInputFile(string fileName)
        {
            List<Route> chart = ReadInputFile(fileName);
            foreach (Route route in chart)
            {
                Chart.TryGetValue(route.Start, out List<(string destination, int distance)> result);
                if (result is null)
                {
                    result = result == null ? new List<(string destination, int distance)>() : result;
                    Chart[route.Start] = result;
                }
                result.Add((route.End, route.Distance));
            }
        }

        public Dictionary<string, List<(string destination, int distance)>> GetChart() => Chart;

        private List<Route> ReadInputFile(string fileName)
        {
            var fqn = Path.Combine(AppContext.BaseDirectory, "InputFiles", fileName);
            //var file = Path.Combine(Directory.GetCurrentDirectory(), "Input.txt");

            string fileContent = File.ReadAllText(fqn);
            string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<Route> chart = new();
            foreach (string line in lines)
            {
                string[] slices = line.Split(',');
                var route = new Route(slices[0], slices[1], Convert.ToInt16(slices[2]));
                chart.Add(route);
            }
            return chart;
        }


    }
}


