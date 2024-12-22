using FluentValidation;
using FluentValidation.Results;
using System.Text;

namespace CalculationServices.Helpers
{
    public static class Helper
    {
        public static void ThrowValidationException(ValidationResult result)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var error in result.Errors)
            {
                builder.Append(error.ErrorMessage);
            }
            var message = builder.ToString();
            throw new ValidationException(message);
        }

        public static bool IsValidNumber(string input)
        {
            return int.TryParse(input, out _);
        }

    }
}
