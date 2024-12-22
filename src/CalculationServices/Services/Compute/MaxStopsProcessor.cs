using CalculationServices.Contracts;
using CalculationServices.Services.Base;
using CalculationServices.Services.Validation;

namespace CalculationServices.Services.Compute
{
    public class MaxStopsProcessor : BaseProcessor
    {

        public MaxStopsProcessor(IRouteChartRepository routeChartRepository, RouteDataValidator routeDataValidator, string filename)
            : base(routeChartRepository, routeDataValidator, filename)
        {
        }

        public List<List<string>> FindAllTriptsWithMaxStops(string tripStart, string tripEnd, int maxStops)
        {
            var allTrips = new List<List<string>>();
            var currentRote = new List<string>();
            FindAllTriptsWithMaxStopsRecursively(tripStart, tripEnd, maxStops, ref allTrips, ref currentRote);
            return allTrips;
        }

        private void FindAllTriptsWithMaxStopsRecursively(string tripStart, string tripEnd, int maxStops, ref List<List<string>> allTrips, ref List<string> currentRoute)
        {
            // aliases 
            var currentJorneyStartStation = tripStart;
            var remainingJourneys = maxStops;

            currentRoute.Add(currentJorneyStartStation);
            if (currentJorneyStartStation == tripEnd && currentRoute.Count() > 1)
            {
                allTrips.Add(new List<string>(currentRoute));
            }
            // No more stops exists
            if (remainingJourneys == 0)
            {
                currentRoute.RemoveAt(currentRoute.Count - 1);
                return;
            }
            if (Chart.ContainsKey(currentJorneyStartStation))
            {
                foreach (var path in Chart[currentJorneyStartStation])
                {
                    FindAllTriptsWithMaxStopsRecursively(path.destination, tripEnd, remainingJourneys - 1, ref allTrips, ref currentRoute);
                }
            }
            currentRoute.RemoveAt(currentRoute.Count - 1);
        }

    }
}
