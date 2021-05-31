using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public class ToppingsManager : IRepo<Toppings>
    {
        private PizzaContext _context;
        private ILogger<ToppingsManager> _logger;
        public ToppingsManager(PizzaContext context, ILogger<ToppingsManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Toppings> GetAll()
        {
            try
            {
                if (_context.Toppings.Count() == 0)
                    return null;
                return _context.Toppings.ToList();

            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;
        }
    }
}
