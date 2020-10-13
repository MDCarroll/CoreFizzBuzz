using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreFizzBuzz.Models;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CoreFizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(int input1, int input2)
        {

            var output = new StringBuilder();
            for (var index = 1; index <= 100; index++)
            {
                if (index % input1 == 0 && index % input2 == 0)
                {
                    output.Append("FizzBuzz ");
                }
                else if (index % input2 == 0)
                {
                    output.Append("Buzz ");
                }
                else if (index % input1 == 0)
                {
                    output.Append("Fizz ");
                }
                else
                {
                    output.AppendLine(index.ToString());
                }

            }
            ViewData["Output"] = output.ToString();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
