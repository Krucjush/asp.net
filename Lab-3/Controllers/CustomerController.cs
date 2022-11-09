using Lab_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_3.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private static int _counter = 1;
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer()
            {
                Email = "adam@op.pl", Id = _counter++, UserName = "Adam",
                Age = 21, PhoneNumber = "123456789", Address = "Nowa Huta 15",
                ZipCode = "31-236", Date = DateTime.Parse("2020-10-23"),
            },
            new Customer()
            {
                Email = "ola@google.pl", Id = _counter++, UserName = "Ola",
                Age = 19, PhoneNumber = "123123123", Address = "Aleja 29 listopada 150",
                ZipCode = "31-251", Date = DateTime.Now,
            },
            new Customer()
            {
                Email = "lukasz@wsei.edu.pl", Id = _counter++, UserName = "Ukasz",
                Age = 27, PhoneNumber = "000000001", Address = "Nowy kleparz 55",
                ZipCode = "31-263", Date = DateTime.Parse("2021-11-23"),
            }
        };
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public ViewResult CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customers.Add(customer);
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
