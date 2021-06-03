using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using PizzaOrderingSystem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepo<Pizza> _repo;
        private ICustpizzarepo<CustPizza> _custpizzarepo;
        private IOrderrepo<Orders> _orderrepo;
        private ICartRepo<Cart> _cartrepo;
        private IRepo<Toppings> _toppingsrepo;
        private IRepo<Crusts> _crustsrepo;
        private PizzaContext _context;


        public HomeController(PizzaContext context,IRepo<Pizza> repo,IRepo<Toppings> toppingsrepo,IRepo<Crusts> crustsrepo,ICustpizzarepo<CustPizza> custpizzarepo, ICartRepo<Cart> cartrepo, IOrderrepo<Orders> orderrepo, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
            _repo = repo;
            _toppingsrepo = toppingsrepo;
            _crustsrepo = crustsrepo;
            _custpizzarepo = custpizzarepo;
            _orderrepo = orderrepo;
            _cartrepo = cartrepo;
        }
        /// <summary>
        /// This is a simple Home page which will have the navigation 
        /// to Our menu page, Cart and About Us page 
        /// </summary>
        public IActionResult Home()
        {
            return View();
        }
        /// <summary>
        /// This will display the List of Pizzas avaliable from the 
        /// Database and allow us to Redirect to the customize page.
        /// </summary>
        public IActionResult Menu()
        {
            List<Pizza> pizzas = _repo.GetAll().ToList();

            return View(pizzas);
           
        }
       
        /// <summary>
        /// This will get the Pizza details from the Menu,
        /// get the Toppings and crust details and move to view,
        /// to display the same.
        /// </summary>

        [HttpGet]
        public IActionResult CustPizza(Pizza pizza)
        {
            var dbcrust = _context.Crusts.ToList();
            ViewBag.crusts = dbcrust.Select(i => i.name).ToList();
            var dbtoppings = _context.Toppings.ToList();
            ViewBag.toppingname = dbtoppings.Select(i=>i.name).ToList();
            ViewBag.toppingamount = dbtoppings.Select(i => i.amount).ToList();
            CustPizza c = new CustPizza();
            c.pizzaId = pizza.id;
            c.name = pizza.name;
            c.perPizzaAmount = pizza.amount;




            return View(c);
        }
        /// <summary>
        /// Once the submit button is clicked it will,
        /// reach this code update the amount of the 
        /// customized pizza (quantity,toppings)
        /// and update in the database.
        /// creates a Cart object copies the custpizza details
        /// and adds to cart.
        /// </summary>

        [HttpPost]
        public IActionResult CustPizza(CustPizza custpizza)
        {
            var dbtoppings = _context.Toppings.ToList();
            var amount = dbtoppings.Where(a => a.name == custpizza.toppings).Select(a => a.amount).FirstOrDefault();
            custpizza.perPizzaAmount = (custpizza.amount + amount) * custpizza.quantity;


            Cart cart = new Cart();
            cart.pizzaname = custpizza.name;
            cart.crust = custpizza.crust;
            cart.toppings = custpizza.toppings;
            cart.quantity = custpizza.quantity;
            cart.custpizzaprice = custpizza.perPizzaAmount;
            _cartrepo.Add(cart);


            return RedirectToAction("Cart","Home");
        }
        /// <summary>
        /// This method will redirected from the CustPizza View ,
        /// get the cart details and and display the same 
        /// through view.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Cart()
        {
            
            try
            {
                List<Cart> cart = _cartrepo.GetAll().ToList();
                return View(cart);
            }
            catch (Exception)
            {

                return RedirectToAction("Noitemcart", "Home");
            }
        }
        /// <summary>
        /// This will catch the exception and return to view
        /// </summary>
        /// <returns></returns>
        public IActionResult Noitemcart()
        {
            return View();
        }
        /// <summary>
        /// This allows the user to delete the item inside the cart
        /// and update the details in the database in the post method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(Cart cart)
        {
            _cartrepo.Delete(cart);
            return RedirectToAction("Cart", "Home");

        }
        /// <summary>
        /// This will be Redirected when the customer
        /// clicks Finalize order present inside cart
        /// and calculated the total amount in the cart
        /// return to view and update to database in the 
        /// post method through interface.
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Orders(Cart cart)
        {
            Orders order = new Orders();
            order.amount= (from i in _context.Cart
                          select i.custpizzaprice).Sum(); 
            
            
            return View(order);
        }
        [HttpPost]
        public IActionResult Orders(Orders order)
        {
            order.amount = (from i in _context.Cart
                            select i.custpizzaprice).Sum();
            _orderrepo.Add(order);
   
            return RedirectToAction("OrderFinalized","Home");
        }
        /// <summary>
        /// This is a success page for the order Finalized.
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderFinalized()
        {
            return View();
        }

        /// <summary>
        /// This will get all the Details from the order tabel in the datbase
        /// and display as order summary.
        /// </summary>
        /// <returns></returns>

        public IActionResult Ordersummary()
        {


                List<Cart> cart = _cartrepo.GetAll().ToList();
                ViewBag.totalamount = (from i in _context.Cart
                                       select i.custpizzaprice).Sum();
                return View(cart);

        }
            /// <summary>
            /// This will catch the exception and return to view
            /// </summary>
            /// <returns></returns>
            /// 
        public IActionResult Noorderyet()
        {
            return View();
        }
        /// <summary>
        /// A simple Static page displays the Details
        /// </summary>
        /// <returns></returns>
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult DeleteCart()
        {
            var delcart = (from i in _context.Cart
                           select i);
            foreach (var item in delcart)
            {
                _context.Cart.Remove(item);
            }
            _context.SaveChanges();
            
            return RedirectToAction("Home", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
