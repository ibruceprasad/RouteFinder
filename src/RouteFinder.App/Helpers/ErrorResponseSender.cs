using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteFinder.App.Helpers
{
    public static class ErrorResponseSender
    {
        public static void PrintValidationErrors(string message) => Console.WriteLine($"Validation exception occured: {message}");

        public static void PrintApplicationErrors(string message) => Console.WriteLine($"Application exception occured: {message}");

        public static void PrintUnknownErrors(string message) => Console.WriteLine($"Internal exception occured: {message}");

     
    }
}
