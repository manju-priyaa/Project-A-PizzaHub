using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Models
{
    public class Cart
    {
        [Key]
        public int id { get; set; }
        public string pizzaname { get; set; }
        public string crust { get; set; }
        public int quantity { get; set; }

        public string toppings { get; set; }
        public double custpizzaprice { get; set; }
    }
}
