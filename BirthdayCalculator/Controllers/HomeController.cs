using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BirthdayCalculator.Models;

namespace BirthdayCalculator.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {

            // Calculate Birthday
            if (person.Birthday.Day == DateTime.Now.Day && person.Birthday.Month == DateTime.Now.Month)
            {
                // Person has its birthday today
                return View("PositiveBirthday", person);
            } else
            {
                // Person doesn't have its birthday today
                return View("NegativeBirthday", person);
            }
        }

        // Birthday positive view
        public IActionResult PositiveBirthday()
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
