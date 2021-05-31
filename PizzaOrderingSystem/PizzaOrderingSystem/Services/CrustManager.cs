using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public class CrustManager:IRepo<Crusts>
    {
        private PizzaContext _context;
        private ILogger<CrustManager> _logger;
        public CrustManager(PizzaContext context, ILogger<CrustManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Crusts> GetAll()
        {
            try
            {
                if (_context.Crusts.Count() == 0)
                    return null;
                return _context.Crusts.ToList();

            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;
        }
    }
}
