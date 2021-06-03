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
        [Required]
        [Range(1, 20, ErrorMessage = "The Quantity should be between 1 to 20")]
        public int quantity { get; set; }
        public string crust { get; set; }
        
        public string toppings { get; set; }

        public double amount { get; set; }  
    }
}
