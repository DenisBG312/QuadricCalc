using Microsoft.AspNetCore.Mvc;
using QuadricCalc.Models;
using System;

namespace QuadricCalc.Controllers
{
    public class QuadricController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(QuadraticCoefficients coefficients)
        {
            // Calculate the roots of the quadratic equation using the coefficients.
            // You can add error handling for invalid input here.

            // Initialize the root variables with default values
            double root1 = 0.0;
            double root2 = 0.0;

            // Calculate the discriminant
            double discriminant = coefficients.B * coefficients.B - 4 * coefficients.A * coefficients.C;

            if (discriminant > 0)
            {
                root1 = (-coefficients.B + Math.Sqrt(discriminant)) / (2 * coefficients.A);
                root2 = (-coefficients.B - Math.Sqrt(discriminant)) / (2 * coefficients.A);
            }
            else if (discriminant == 0)
            {
                root1 = root2 = -coefficients.B / (2 * coefficients.A);
            }
            else
            {
                // Handle complex roots or any other error cases.
                // You can customize this part according to your needs.
            }

            // Pass the calculated roots to the Index view
            ViewData["Root1"] = root1;
            ViewData["Root2"] = root2;

            return View("Index");
        }
    }
}