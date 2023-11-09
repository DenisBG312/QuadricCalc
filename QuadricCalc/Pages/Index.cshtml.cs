﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace QuadricCalc.Pages.QuadraticEquation
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string InputEquation { get; set; }
        public bool Calculated { get; private set; }
        public double CoefficientA { get; private set; }
        public double CoefficientB { get; private set; }
        public double CoefficientC { get; private set; }
        public double Root1 { get; private set; }
        public double Root2 { get; private set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(InputEquation))
            {
                try
                {
                    string[] equationParts = InputEquation.Split(' ');

                    if (equationParts.Length >= 4)
                    {
                        CoefficientA = double.Parse(equationParts[0].Replace("x2", "").Trim());
                        CoefficientB = double.Parse(equationParts[2].Replace("x", "").Trim());
                        CoefficientC = double.Parse(equationParts[4].Trim());

                        double discriminant = CoefficientB * CoefficientB - 4 * CoefficientA * CoefficientC;

                        if (discriminant > 0)
                        {
                            Root1 = (-CoefficientB + Math.Sqrt(discriminant)) / (2 * CoefficientA);
                            Root2 = (-CoefficientB - Math.Sqrt(discriminant)) / (2 * CoefficientA);
                        }
                        else if (discriminant == 0)
                        {
                            Root1 = Root2 = -CoefficientB / (2 * CoefficientA);
                        }

                        Calculated = true;
                    }
                }
                catch (FormatException)
                {
                    // Handle parsing errors
                }
            }
        }
    }
}
