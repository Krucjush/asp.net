using asp.net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace FirstApp.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public string Hello()
        {
            string name = Request.Query["name"];
            string age = Request.Query["age"];
            if (int.TryParse(age, out int x))
            {
                Response.StatusCode = 200;
                return $"Hello {name}, you are {age} y.o. and born in {DateTime.Now.Year - x}";
            }
            else
            {
                Response.StatusCode = 400;
                return "";
            }

        }

        public IActionResult Birth(UserInfo userInfo)
        {
            if (userInfo.Name == null || userInfo.Age == null)
            {
                Response.StatusCode = 400;
                return View();
            }
            else
            {
                string message = $"Hello {userInfo.Name}, your birth year is {DateTime.Now.Year - userInfo.Age}.";
                ViewBag.message = message;
                return View();
            }
        }

        public IActionResult Calculator(CalculatorInfo calculatorInfo)
        {
            if (calculatorInfo.A == null || calculatorInfo.B == null)
            {
                Response.StatusCode = 400;
                return View();
            }
            else if (calculatorInfo.Op == "add")
            {
                ViewBag.message = $"{calculatorInfo.A} + {calculatorInfo.B} = {calculatorInfo.A + calculatorInfo.B}";
                return View();
            }
            else if (calculatorInfo.Op == "sub")
            {
                ViewBag.message = $"{calculatorInfo.A} - {calculatorInfo.B} = {calculatorInfo.A - calculatorInfo.B}";
                return View();
            }
            else if (calculatorInfo.Op == "mul")
            {
                ViewBag.message = $"{calculatorInfo.A} * {calculatorInfo.B} = {calculatorInfo.A * calculatorInfo.B}";
                return View();
            }
            else if (calculatorInfo.Op == "div")
            {
                ViewBag.message = $"{calculatorInfo.A} + {calculatorInfo.B} = {calculatorInfo.A / calculatorInfo.B}";
                return View();
            }
            else if (calculatorInfo.Op == "mod")
            {
                ViewBag.message = $"{calculatorInfo.A} % {calculatorInfo.B} = {calculatorInfo.A % calculatorInfo.B}";
                return View();
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}