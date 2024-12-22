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

        [Fact]
        public void Test_MaxStopsProcessor()
        {
            // Arrange 
            var actual = new List<string>();
            MaxStopsProcessor processor = new MaxStopsProcessor(routeChartRepository, validator, "Input.txt");
            var expected = new List<string>() { "C=>D=>C", "C=>E=>B=>C" };

            //Act
            var result = processor.FindAllTriptsWithMaxStops("C", "C", 3);
            foreach (var r in result)
            {
                var route = string.Join("=>", r);
                actual.Add(route);
            }

            // Assert
            expected.Should().BeEquivalentTo(actual);
        }
    }
}
