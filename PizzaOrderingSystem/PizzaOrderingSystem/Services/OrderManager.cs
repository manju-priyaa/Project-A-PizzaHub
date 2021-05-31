using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public class OrderManager:IOrderrepo<Orders>
    {

            private PizzaContext _context;
            private ILogger<OrderManager> _logger;
            public OrderManager(PizzaContext context, ILogger<OrderManager> logger)
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

 
            public IEnumerable<Orders> GetAll()
            {
                try
                {
                    if (_context.Orders.Count() == 0)
                        return null;
                    return _context.Orders.ToList();

                }
                catch (Exception e)
                {

                    _logger.LogDebug(e.Message);
                }
                return null;
            }

        }
    }

