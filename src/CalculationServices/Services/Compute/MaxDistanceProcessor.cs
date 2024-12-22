using CalculationServices.Contracts;
using CalculationServices.Services.Base;
using CalculationServices.Services.Validation;


namespace CalculationServices.Services.Compute
{
    public class MaxDistanceProcessor : BaseProcessor
    {

        public MaxDistanceProcessor(IRouteChartRepository routeChartRepository, RouteDataValidator routeDataValidator, string filename)
           : base(routeChartRepository, routeDataValidator, filename)
        {
        }

        public List<List<string>> FindAllTriptsWithMaxDistance(string tripStart, string tripEnd, int maxDistance)
        {
            var allTrips = new List<List<string>>();
            var currentRote = new List<string>();
            FindAllTriptsWithMaxDistanceRecursively(tripStart, tripEnd, maxDistance, ref allTrips, ref currentRote);
            return allTrips;
        }

        private void FindAllTriptsWithMaxDistanceRecursively(string tripStart, string tripEnd, int maxDistance, ref List<List<string>> allTrips, ref List<string> currentRoute)
        {
            // aliases 
            var currentJorneyStartStation = tripStart;
            var remainingDistance = maxDistance;

            currentRoute.Add(currentJorneyStartStation);
            if (remainingDistance > 0 && currentJorneyStartStation == tripEnd && currentRoute.Count() > 1)
            {
                allTrips.Add(new List<string>(currentRoute));
            }
            // No more stops exists
            if (remainingDistance < 0)
            {
                currentRoute.RemoveAt(currentRoute.Count - 1);
                return;
            }
            if (Chart.ContainsKey(currentJorneyStartStation))
            {
                foreach (var path in Chart[currentJorneyStartStation])
                {
                    FindAllTriptsWithMaxDistanceRecursively(path.destination, tripEnd, remainingDistance - path.distance, ref allTrips, ref currentRoute);
                }
            }
            currentRoute.RemoveAt(currentRoute.Count - 1);
        }

    }
}
