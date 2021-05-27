using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Models
{
    public class Pizza
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool isVeg { get; set; }

        public double amount { get; set; }

    }
}
