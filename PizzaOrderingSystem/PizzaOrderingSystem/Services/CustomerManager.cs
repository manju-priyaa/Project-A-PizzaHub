using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public class CustomerManager:ICustpizzarepo<Orders>
    {
        private PizzaContext _context;
        private ILogger<CustomerManager> _logger;
        public CustomerManager(PizzaContext context, ILogger<CustomerManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Orders t)
        {
            try
            {
                _context.Orders.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
        }
    }
}
