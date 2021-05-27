using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Models
{
    public class Toppings
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public double amount { get; set; }
    }
}
