using FluentAssertions.Equivalency;
using RouteService.Models;
using RouteService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node = RouteService.Services.Node;

namespace TrainRouteFinder.Tests
{
    public class Test6
    {
        public RouteChartContext RouteChartContext { get; }
        public GraphChartContext GraphChartContext { get; } 
        public Test6()
        {
            var routes = new List<Route>()
            {
                new Route("A", "B", 5),
                new Route("B", "C", 4),
                new Route("C", "D", 8),
                new Route("D", "C", 8),
                new Route("D", "E", 6),
                new Route("A", "D", 5),
                new Route("C", "E", 2),
                new Route("E", "B", 3),
                new Route("A", "E", 7)
            };
            var routeChart = new RouteChart(routes);
            RouteChartContext = new RouteChartContext(routeChart);
            GraphChartContext = new GraphChartContext(routeChart);

        }
        [Fact]

        public void Test_Number_Of_Trips_Between_C_C()
        {

            var routes = new List<Route>()
            {
                new Route("A", "B", 5),
                new Route("B", "C", 4),
                new Route("C", "D", 8),
                new Route("D", "C", 8),
                new Route("D", "E", 6),
                new Route("A", "D", 5),
                new Route("C", "E", 2),
                new Route("E", "B", 3),
                new Route("A", "E", 7)
            };
            var routeChart = new RouteChart(routes);

            GraphChartContext graphChartContext = new GraphChartContext(routeChart);    


            //// Arrange
            //var routeChartRepository = new RouteChartRepository(RouteChartContext);
            //// Act
            //List<List<string>> results = null;
            //List<string> route = null;

            //var x = routeChartRepository.GetAllTrips("A", "C", ref results!, ref  route!);
            //var y = x;

            //Calculator calculator = new Calculator();
            //var allRoutes = calculator.FindAllRoutes("C", "C", 3);
            //var allRoutes1 = calculator.FindAllRoutesExactly("A", "C", 4);

            //var list = allRoutes1.Where(x=>x.Count() == 5).ToList();

            //Graph Cities = new Graph();


            //Node NewYork = new Node("New York");
            //Node Miami = new Node("Miami");
            //Node Chicago = new Node("Chicago");
            //Node Dallas = new Node("Dallas");
            //Node Denver = new Node("Denver");
            //Node SanFrancisco = new Node("San Francisco");
            //Node LA = new Node("Los Angeles");
            //Node SanDiego = new Node("San Diego");

            //Cities.Add(NewYork);
            //Cities.Add(Miami);
            //Cities.Add(Chicago);
            //Cities.Add(Dallas);
            //Cities.Add(Denver);
            //Cities.Add(SanFrancisco);
            //Cities.Add(LA);
            //Cities.Add(SanDiego);

            //NewYork.AddNeighbour(Chicago, 75);
            //NewYork.AddNeighbour(Miami, 90);
            //NewYork.AddNeighbour(Dallas, 125);
            //NewYork.AddNeighbour(Denver, 100);

            //Miami.AddNeighbour(Dallas, 50);

            //Dallas.AddNeighbour(SanDiego, 90);
            //Dallas.AddNeighbour(LA, 80);

            //SanDiego.AddNeighbour(LA, 45);

            //Chicago.AddNeighbour(SanFrancisco, 25);
            //Chicago.AddNeighbour(Denver, 20);

            //SanFrancisco.AddNeighbour(LA, 45);

            //Denver.AddNeighbour(SanFrancisco, 75);
            //Denver.AddNeighbour(LA, 100);


            DistanceCalculator calc = new DistanceCalculator(graphChartContext);
            calc.Calculate("B", "E");


        }
    }
}
