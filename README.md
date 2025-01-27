# Project - RouteFinder

The project is a .NET 8 Console application that includes both source code `(src/)` and tests `(tests/)`.

The `src/` directory contains a primary project `RouteFinder.App/`, along with two class libraries: `CalculationServices/` and `RepositoryServices/`. 
These class libraries are registered as dependencies in the main project.

The `RepositoryServices/` is responsible for supplying data to `CalculationServices/`. 
It reads the input file, creates a dictionary collection named Chart, and exposes it to `CalculationServices/`.


The `CalculationServices/` directory is responsible for providing the necessary command-line handler from the Calculation Factory class.

The `xUnit` test project `RouteFinder.Tests/` covers all the test scenarios mentioned in the requirement<br>
 


**Project structure:**<br><br>

![image](https://github.com/user-attachments/assets/ee0942fa-bdea-4ae3-a3dd-9ad83d546133)

 

**Project Execution:**

![image](https://github.com/user-attachments/assets/fb7c4630-03eb-43a1-96bc-8ab9072b8a7d)
