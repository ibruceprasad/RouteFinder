﻿using FluentAssertions;
using RouteService.Models;
using RouteService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainRouteFinder.Tests
{
    public class Test3
    {
        public RouteChartContext RouteChartContext { get; }
        public Test3()
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
        }


        [Fact]
        public void Test_Distance_Between_Route_A_D_C()
        {
            // Arrange
            var routeChartRepository = new RouteChartRepository(RouteChartContext);
            // Act
            var distance = routeChartRepository.GetRouteDistance(new List<string>() { "A", "D", "C" });
            // Assert
            distance.Should().Be(13);
        }
    }
}