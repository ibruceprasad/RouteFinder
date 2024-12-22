using CalculationServices.Contracts;
using CalculationServices.Services.Base;
using CalculationServices.Services.Validation;


namespace CalculationServices.Services.Compute
{
    public class ExactStopsProcessor : BaseProcessor
    {
        public ExactStopsProcessor(IRouteChartRepository routeChartRepository, RouteDataValidator routeDataValidator, string filename)
        : base(routeChartRepository, routeDataValidator, filename)
        {
        }

        public List<List<string>> FindAllTriptsWithExactStops(string tripStart, string tripEnd, int exactStops)
        {
            var allTrips = new List<List<string>>();
            var currentRote = new List<string>();
            FindAllTriptsWithExactStopsRecursively(tripStart, tripEnd, exactStops, ref allTrips, ref currentRote);
            return allTrips;
        }

        private void FindAllTriptsWithExactStopsRecursively(string tripStart, string tripEnd, int exactStops, ref List<List<string>> allTrips, ref List<string> currentRoute)
        {
            // aliases 
            var currentJorneyStartStation = tripStart;
            var remainingJourneys = exactStops;

            currentRoute.Add(currentJorneyStartStation);
            if (remainingJourneys == 0 && currentJorneyStartStation == tripEnd && currentRoute.Count() > 1)
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
                    FindAllTriptsWithExactStopsRecursively(path.destination, tripEnd, remainingJourneys - 1, ref allTrips, ref currentRoute);
                }
            }
            currentRoute.RemoveAt(currentRoute.Count - 1);
        }
    }
}