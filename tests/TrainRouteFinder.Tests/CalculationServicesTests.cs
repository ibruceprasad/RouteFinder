using CalculationServices.Contracts;
using CalculationServices.Services.Compute;
using CalculationServices.Services.Validation;
using FluentAssertions;
using RepositoryServices.Services;


namespace RouteFinder.Tests
{
    public class CalculationServicesTests
    {
        private readonly RouteDataValidator validator;
        private readonly IRouteChartRepository routeChartRepository;
        
        public CalculationServicesTests()
        {
            validator = new RouteDataValidator();
            routeChartRepository = new RouteChartRepository();
        }
        
        
        // Test #6
        [Fact]
        public void Test_6_FindAllTriptsWithMaxStops()
        {
            // Arrange 
            var processor = new MaxStopsProcessor(routeChartRepository, validator, "Input.txt");
            var expected = new List<string>() { "C=>D=>C", "C=>E=>B=>C" };

            //Act
            var actual = new List<string>();
            var result = processor.FindAllTriptsWithMaxStops("C", "C", 3);
            foreach (var r in result)
            {
                var route = string.Join("=>", r);
                actual.Add(route);
            }

            // Assert
            expected.Should().BeEquivalentTo(actual);
        }


        // Test #5 
        [Fact]
        public void Test_5_IsRouteExists()
        {
            // Arrange 
            var processor = new RouteCheckProcessor(routeChartRepository, validator, "Input.txt");
            var expected = false;

            //Act
            var result = processor.IsRouteExists(new List<string>() { "A", "E", "D" });
            var actual = result;

            // Assert
            expected.Should().Be(actual);
        }


        // Test #10 
        [Fact]
        public void Test_10_FindAllTriptsWithMaxDistance()
        {
            // Arrange 
            var processor = new MaxDistanceProcessor(routeChartRepository, validator, "Input.txt");
            var expected = new List<string>() { "C=>D=>C", "C=>D=>C=>E=>B=>C", "C=>D=>E=>B=>C", "C=>E=>B=>C", "C=>E=>B=>C=>D=>C",
                "C=>E=>B=>C=>E=>B=>C", "C=>E=>B=>C=>E=>B=>C=>E=>B=>C"  };

            //Act
            var actual = new List<string>();
            var result = processor.FindAllTriptsWithMaxDistance("C", "C", 30);
            foreach (var r in result)
            {
                var route = string.Join("=>", r);
                actual.Add(route);
            }

            // Assert
            expected.Should().BeEquivalentTo(actual);
        }


        // Test #7 
        [Fact]
        public void Test_7_FindAllTriptsWithExactStops()
        {
            // Arrange 
            var processor = new ExactStopsProcessor(routeChartRepository, validator, "Input.txt");
            var expected = new List<string>() {   "A=>B=>C=>D=>C", "A=>D=>C=>D=>C", "A=>D=>E=>B=>C"  };

            //Act
            var actual = new List<string>();
            var result = processor.FindAllTriptsWithExactStops("A", "C", 4);
            foreach (var r in result)
            {
                var route = string.Join("=>", r);
                actual.Add(route);
            }

            // Assert
            expected.Should().BeEquivalentTo(actual);
        }

        // Test #1 #2 #3 #4
        public static IEnumerable<object[]> RouteDistanceData => new List<object[]>
        {
            new object[] { new string[] { "A", "B", "C" }, 9  },
            new object[] { new string[] { "A", "D" }, 5 },
            new object[] { new string[] { "A", "D", "C" }, 13  },
            new object[] { new string[] { "A", "E", "B", "C", "D" }, 22 }
        };

        [Theory]
        [MemberData(nameof(RouteDistanceData))]
        
        public void Test_1_to_4_FindRouteDistance(string[] route, int expected)
        {
            // Arrange 
            var processor = new DistanceProcessor(routeChartRepository, validator, "Input.txt");
            
            //Act
            var result = processor.FindRouteDistance(route.ToList());
            var actual = result;
            // Assert
            expected.Should().Be(actual);
        }

        // Test #8 #9
        public static IEnumerable<object[]> ShortestDistanceData => new List<object[]>
        {
            new object[] {   "A", "C", "A=>B=>C"  },
            new object[] {   "B", "B", "B=>C=>E=>B"}
        };

   
        [Theory]
        [MemberData(nameof(ShortestDistanceData))]
        public void Test_8_And_9_GetShortestRoute( string start, string end, string expected )
        {
            // Arrange 
            var processor = new ShortestRouteProcessor(routeChartRepository, validator, "Input.txt");

            //Act
            var r = processor.GetShortestRoute( start,end);
            var route = string.Join("=>", r);
          
            var actual = route;
            // Assert
            expected.Should().Be(actual);
        }

    }
}
