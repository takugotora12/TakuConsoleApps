using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApps.Models;
using ConsoleAppProject.App02;
using ConsoleAppProject.App01;

namespace WebApps.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DistanceConverter(DistanceConverter converter)
        {
            if (converter.FromDistance > 0)
            {
                converter.CalculateDistance();
            }
            return View(converter);
        }

        [HttpGet]
        public IActionResult BMICalculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BMICalculator(BMI_Calculator bmi)
        {
            if (bmi.Centimeters > 140)
            {
                bmi.CalculateMetric();
            }
            else if (bmi.Feet > 4 && bmi.Stones > 6)
            {
                bmi.CalculateImperial();
            }
            else
            {
                ViewBag.Error = "You have entered values too small for any adult!";
                return View();
            }

            double bmiIndex = bmi.BmiIndex;

            return RedirectToAction("HealthMessage", new { bmiIndex });
        }
        public IActionResult HealthMessage(double bmiIndex)
        {
            return View(bmiIndex);
        }

        public IActionResult StudentMarks()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
