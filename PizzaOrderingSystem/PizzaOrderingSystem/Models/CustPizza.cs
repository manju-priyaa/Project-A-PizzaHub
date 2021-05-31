using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingSystem.Models
{
    public class CustPizza
    {
        [Key]
        public int id { get; set; }
        
        [ForeignKey("Pizza")]
        public int pizzaId { get; set; }

        public string name { get; set; }

        public double perPizzaAmount { get; set; }

        public int quantity { get; set; }

        public string crust { get; set; }

        public string toppings { get; set; }

        public double amount { get; set; }  
    }
}
