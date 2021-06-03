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
        [Required(ErrorMessage ="Please Enter Your Name.")]
        public string customerName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Phone Number.")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address.")]
        public string address { get; set; }
        [Required(ErrorMessage = "Please  Enter your Prefered Delivery Date.")]
        public DateTime  datetime { get; set; }
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public double amount { get; set; }
    }
}
