using CalculationServices.Contracts;
using CalculationServices.Services.Base;
using CalculationServices.Services.Validation;

namespace CalculationServices.Services.Compute
{
    public class ShortestRouteProcessor : BaseProcessor
    {

        public ShortestRouteProcessor(IRouteChartRepository routeChartRepository, RouteDataValidator routeDataValidator, string filename)
                : base(routeChartRepository, routeDataValidator, filename)
        {
        }

        public List<string> GetShortestRoute(string start, string end)
        {
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var nodes = new List<string>();

            foreach (var vertex in Chart.Keys)
            {
                if (vertex == start)
                    distances[vertex] = 0;
                else
                    distances[vertex] = int.MaxValue;

                nodes.Add(vertex);
            }

            while (nodes.Count > 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);
                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == end)
                {
                    var path = new List<string>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Insert(0, smallest);
                        smallest = previous[smallest];
                    }

                    path.Insert(0, start);
                    return path;
                }

                if (distances[smallest] == int.MaxValue)
                    break;

                foreach (var neighbor in Chart[smallest])
                {
                    var alt = distances[smallest] + neighbor.Item2;
                    if (alt < distances[neighbor.Item1])
                    {
                        distances[neighbor.Item1] = alt;
                        previous[neighbor.Item1] = smallest;
                    }
                }
            }
            return new List<string>();
        }
    }
}
