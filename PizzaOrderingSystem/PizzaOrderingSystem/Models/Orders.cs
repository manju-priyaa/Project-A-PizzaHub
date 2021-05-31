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

        public string customerName { get; set; }
        public string phoneNumber { get; set; }

        public string address { get; set; }
        public DateTime  datetime { get; set; }
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public double amount { get; set; }
    }
}
