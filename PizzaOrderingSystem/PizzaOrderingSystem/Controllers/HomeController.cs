using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using PizzaOrderingSystem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepo<Pizza> _repo;

        public HomeController(IRepo<Pizza> repo,ILogger<HomeController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Menu()
        {
            List<Pizza> pizzas = _repo.GetAll().ToList();
            return View(pizzas);
           
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult CustPizza(Pizza pizza)
        {
            return View(pizza);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
