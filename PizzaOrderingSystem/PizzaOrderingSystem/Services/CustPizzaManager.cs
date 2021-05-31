using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public class CustPizzaManager:ICustpizzarepo<CustPizza>
    {
        private PizzaContext _context;
        private ILogger<CustPizzaManager> _logger;
        public CustPizzaManager(PizzaContext context, ILogger<CustPizzaManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(CustPizza t)
        {
            try
            {
                _context.CustPizzas.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
        }
    }
}
