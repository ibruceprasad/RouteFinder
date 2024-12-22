# Project - RouteFinder

The project is a .NET 8 Console application that includes both source code `(src/)` and tests `(tests/)`.

The `src/` directory contains a primary project `RouteFinder.App/`, along with two class libraries: `CalculationServices/` and `RepositoryServices/`. 
These class libraries are registered as dependencies in the main project.

The `RepositoryServices/` is responsible for supplying data to `CalculationServices/`. 
It reads the input file, creates a dictionary collection named Chart, and exposes it to `CalculationServices/`.


The `CalculationServices/` directory is responsible for providing the necessary command-line handler from the Calculation Factory class.

The `xUnit` test project `RouteFinder.Tests/` covers all the test scenarios mentioned in the requirement<br>
Note: The test case Test #9: The length of the shortest route from B to B is 9 ( B=>C=>E=>B ) fails
