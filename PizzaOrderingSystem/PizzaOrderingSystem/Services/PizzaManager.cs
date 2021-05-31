using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public class PizzaManager:IRepo<Pizza>
    {
        private PizzaContext _context;
        private ILogger<PizzaManager> _logger;
        public PizzaManager(PizzaContext context, ILogger<PizzaManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Pizza> GetAll()
        {
            try
            {
                if (_context.Pizzas.Count() == 0)
                    return null;
                return _context.Pizzas.ToList();

            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;
        }
    }
}
