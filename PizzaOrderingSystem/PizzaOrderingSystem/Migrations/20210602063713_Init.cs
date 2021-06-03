using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaOrderingSystem.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pizzaname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    toppings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custpizzaprice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustPizzas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pizzaId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    perPizzaAmount = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    crust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    toppings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustPizzas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isVeg = table.Column<bool>(type: "bit", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Flat Bread" },
                    { 2, "Thin Crust" },
                    { 3, "Double Dough" },
                    { 4, "Stuffed Crust" },
                    { 5, "Vegan Friendly" },
                    { 6, "Pizza Bagels" },
                    { 7, "Silican Style" },
                    { 8, "Chicago Deep Dish" },
                    { 9, "NY Style Pizza" },
                    { 10, "Neapolitan Pizza" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "id", "amount", "description", "image", "isVeg", "name" },
                values: new object[,]
                {
                    { 8, 899.99000000000001, "Speacially made with Barbeque Chicken and golden corn to make extra tasty!!!", "~/imgs/img1.jpg", false, "Chicken Golden Light" },
                    { 7, 799.99000000000001, "Speacially made with Meal Makers to make extra tasty!!!", "~/imgs/soya.png", true, "Soya Golden Light" },
                    { 6, 599.99000000000001, "Speacially made with pepper Chicken and onions  to make extra tasty!!!", "~/imgs/pepperandchicken.jpg", false, "Pepper Barbecure & Onion" },
                    { 5, 499.99000000000001, "Speacially made with BabyCorn and then grilled to make extra tasty!!!", "~/imgs/babycorn.jpg", true, "Baby Corn Grilled" },
                    { 3, 799.99000000000001, "Speacially made with Chicken and then grilled to make extra tasty!!!", "~/imgs/chicken.jpg", false, "Chicken Grilled Pizza" },
                    { 2, 599.99000000000001, "Speacially made with Mushroom  to make extra tasty!!!", "~/imgs/mushroom.jpg", true, "Mushroom Tandoori Pizza" },
                    { 1, 499.99000000000001, "Speacially made with Paneer and then grilled to make extra tasty!!!", "~/imgs/panner.jpg", true, "Paneer Grilled Pizza" },
                    { 4, 699.99000000000001, "Speacially made with Bacon Sausage and then grilled to make extra tasty!!!", "~/imgs/Baconpizza.jpg", false, "Bacon Grilled Pizza" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "id", "amount", "name" },
                values: new object[,]
                {
                    { 10, 80.0, "Spinach(+80 Rs)" },
                    { 1, 0.0, "None" },
                    { 2, 30.0, "Pepperoni(+30 Rs)" },
                    { 3, 40.0, "Mushroom(+40 Rs)" },
                    { 4, 50.0, "Onions(+50 Rs)" },
                    { 5, 70.0, "Bacon(+70 Rs)" },
                    { 6, 80.0, "Extra Cheese(+80 Rs)" },
                    { 7, 90.0, "Black Olives(+90 Rs)" },
                    { 8, 100.0, "Green Peppers(+100 Rs)" },
                    { 9, 150.0, "Sausage(+150 Rs)" },
                    { 11, 90.0, "Pineapple(+90 Rs)" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "CustPizzas");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
