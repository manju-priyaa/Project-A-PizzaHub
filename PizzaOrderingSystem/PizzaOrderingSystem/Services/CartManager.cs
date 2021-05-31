using Microsoft.Extensions.Logging;
using PizzaOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Services
{
    public class CartManager:ICartRepo<Cart>
    {
        private PizzaContext _context;
        private ILogger<CartManager> _logger;
        public CartManager(PizzaContext context, ILogger<CartManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Cart t)
        {
            try
            {
                _context.Cart.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
        }

        public void Delete(Cart t)
        {
            try
            {
                _context.Cart.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
        }

        public Cart Get(int id)
        {
            try
            {
                Cart cart = _context.Cart.FirstOrDefault(a => a.id == id);
                return cart;

            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;

        }

        public IEnumerable<Cart> GetAll()
        {
            try
            {
                if (_context.Cart.Count() == 0)
                    return null;
                return _context.Cart.ToList();
              
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;
        }

    }
}

