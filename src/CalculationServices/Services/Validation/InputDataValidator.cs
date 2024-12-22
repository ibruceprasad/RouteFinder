using FluentValidation;
using RouteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace CalculationServices.Services.Validation
{
    public class RouteDataValidator : AbstractValidator<Dictionary<string, List<(string destination, int distance)>>>
    {
        public RouteDataValidator()
        {
            RuleForEach(dict => dict.Keys)
            .NotEmpty()
            .WithMessage("Route name cannot be empty.")
            .MaximumLength(50)
            .WithMessage("Route name must be max 50 chars.");

            RuleForEach(dict => dict.Values).ChildRules(list =>
            {
                list.RuleForEach(entry => entry)
                .Must(entry => !string.IsNullOrWhiteSpace(entry.destination))
                .WithMessage("Destination cannot be empty.")
                .Must(entry => entry.distance > 0 && entry.distance < short.MaxValue)
                .WithMessage("Distance must be greater than zero.");
            });
        }
    }
}
