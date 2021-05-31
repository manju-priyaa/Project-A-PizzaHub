using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaOrderingSystem.Models;

namespace PizzaOrderingSystem.Models
{
    public class PizzaContext:DbContext
    {
        public PizzaContext()
        {

        }
        public PizzaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CustPizza> CustPizzas { get; set; }
        public DbSet<Crusts> Crusts { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<Orders> Orders { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { id = 1, name = "Paneer Grilled Pizza", description = "Speacially made with Paneer and then grilled to make extra tasty!!!",isVeg=true,amount=499.99 });
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { id = 2, name = "Mushroom Tandoori Pizza", description = "Speacially made with Mushroom  to make extra tasty!!!", isVeg = true, amount = 599.99 });
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { id = 3, name = "Chicken Grilled Pizza", description = "Speacially made with Chicken and then grilled to make extra tasty!!!", isVeg = false, amount = 799.99 });
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { id = 4, name = "Bacon Grilled Pizza", description = "Speacially made with Bacon Sausage and then grilled to make extra tasty!!!", isVeg = false, amount = 699.99 });
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { id = 5, name = "Baby Corn Grilled", description = "Speacially made with BabyCorn and then grilled to make extra tasty!!!", isVeg = true, amount = 499.99 });
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { id = 6, name = "Pepper Barbecure & Onion", description = "Speacially made with pepper Chicken and onions  to make extra tasty!!!", isVeg = false, amount = 599.99 });
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { id = 7, name = "Soya Golden Light", description = "Speacially made with Meal Makers to make extra tasty!!!", isVeg = true, amount = 799.99 });
            modelBuilder.Entity<Pizza>().HasData(new Pizza() { id = 8, name = "Chicken Golden Light", description = "Speacially made with Barbeque Chicken and golden corn to make extra tasty!!!", isVeg = false, amount = 899.99 });

            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 1, name = "Pepperoni(+30 Rs)",amount = 30 });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 2, name = "Mushroom(+40 Rs)", amount = 40 });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 3, name = "Onions(+50 Rs)", amount = 50 });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 4, name = "Bacon(+70 Rs)", amount = 70 });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 5, name = "Extra Cheese(+80 Rs)", amount =80  });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 6, name = "Black Olives(+90 Rs)", amount = 90 });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 7, name = "Green Peppers(+100 Rs)", amount = 100 });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 8, name = "Sausage(+150 Rs)", amount = 150 });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 9, name = "Spinach(+80 Rs)", amount = 80 });
            modelBuilder.Entity<Toppings>().HasData(new Toppings() { id = 10, name = "Pineapple(+90 Rs)", amount = 90 });


            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 1, name = "Flat Bread"});
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 2, name = "Thin Crust"});
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 3, name = "Double Dough" });
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 4, name = "Stuffed Crust"});
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 5, name = "Vegan Friendly" });
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 6, name = "Pizza Bagels" });
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 7, name = "Silican Style" });
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 8, name = "Chicago Deep Dish" });
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 9, name = "NY Style Pizza" });
            modelBuilder.Entity<Crusts>().HasData(new Crusts() { id = 10, name = "Neapolitan Pizza" });


        }
        
    }
}
