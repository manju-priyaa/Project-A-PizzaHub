using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Models
{
    public class Orders
    {
        [Key]
        public int id { get; set; }

        public int customerId { get; set; }

        public double amount { get; set; }

        [ForeignKey("Cart")]
        public int cartId { get; set; }
    }
}
