using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Models
{
    public class Cart
    {
        [Key]
        public int id { get; set; }

        public double totalAmount { get; set; }
    }
}
