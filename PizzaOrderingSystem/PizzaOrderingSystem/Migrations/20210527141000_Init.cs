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
                    totalAmount = table.Column<double>(type: "float", nullable: false)
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
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustPizzas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pizzaId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    perPizzaAmount = table.Column<double>(type: "float", nullable: false),
                    toppingAmount = table.Column<double>(type: "float", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    cartId = table.Column<int>(type: "int", nullable: false)
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
                    customerId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    cartId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "id", "amount", "description", "isVeg", "name" },
                values: new object[,]
                {
                    { 8, 899.99000000000001, "Speacially made with Barbeque Chicken and golden corn to make extra tasty!!!", false, "Chicken Golden Light" },
                    { 7, 799.99000000000001, "Speacially made with Meal Makers to make extra tasty!!!", true, "Soya Golden Light" },
                    { 6, 599.99000000000001, "Speacially made with pepper Chicken and onions  to make extra tasty!!!", false, "Pepper Barbecure & Onion" },
                    { 5, 499.99000000000001, "Speacially made with BabyCorn and then grilled to make extra tasty!!!", true, "Baby Corn Grilled" },
                    { 4, 699.99000000000001, "Speacially made with Bacon Sausage and then grilled to make extra tasty!!!", false, "Bacon Grilled Pizza" },
                    { 3, 799.99000000000001, "Speacially made with Chicken and then grilled to make extra tasty!!!", false, "Chicken Grilled Pizza" },
                    { 2, 599.99000000000001, "Speacially made with Mushroom  to make extra tasty!!!", true, "Mushroom Tandoori Pizza" },
                    { 1, 499.99000000000001, "Speacially made with Paneer and then grilled to make extra tasty!!!", true, "Paneer Grilled Pizza" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "id", "amount", "name" },
                values: new object[,]
                {
                    { 1, 30.0, "Pepperoni" },
                    { 2, 40.0, "Mushroom" },
                    { 3, 50.0, "Onions" },
                    { 4, 70.0, "Bacon" },
                    { 5, 80.0, "Extra Cheese" },
                    { 6, 89.0, "Black Olives" },
                    { 7, 100.0, "Green Peppers" },
                    { 8, 150.0, "Sausage" },
                    { 9, 80.0, "Spinach" },
                    { 10, 90.0, "Pineapple" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Customers");

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
