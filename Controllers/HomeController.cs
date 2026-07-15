using Microsoft.AspNetCore.Mvc;
using Naborious_Coffe_FS.Models;

namespace Naborious_Coffe_FS.Controllers
{
    public class HomeController : Controller
    {
        // HTML page that will be rendered when the user accesses the root URL of the application
        public IActionResult Index()
        {
            return View();
        }

        // This new route acts as an API (/Home/GetProducts) that returns JSON
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Type = "coffee", Title = "Espresso", ShortDescription = "Strong and aromatic Italian coffee", Description = "A strong and bold coffee made by forcing hot water through finely-ground coffee beans.", Price = "$3.50", Image = "/images/espresso.jpg" },
                new Product { Type = "coffee", Title = "Latte", ShortDescription = "Unique and decent creamy coffe drink", Description = "A creamy coffee made with espresso and steamed milk, topped with a small amount of foam.", Price = "$4.00", Image = "/images/latte.jpg" },
                new Product { Type = "coffee", Title = "Cappuccino", ShortDescription = "A coffee drink made with steamed milk foam", Description = "A coffee drink made with espresso and steamed milk, topped with a layer of foam.", Price = "$4.50", Image = "/images/cappucino.jpg" },
                new Product { Type = "coffee", Title = "Milkshake", ShortDescription = "Delicious creamy milk drink", Description = "A creamy milk-based drink made with ice cream and flavoring, often served in a tall glass.", Price = "$5.50", Image = "/images/milkshake.jpg" },
                new Product { Type = "coffee", Title = "Macchiato", ShortDescription = "Exotic but delicious coffee with a shot of espresso", Description = "A coffee drink made with a shot of espresso and a small amount of steamed milk, often served in a small cup.", Price = "$4.50", Image = "/images/macchiato.jpg" },
                new Product { Type = "coffee", Title = "Chai Latte", ShortDescription = "Fabulous coffee made with a tea and milk", Description = "A creamy coffee drink made with chai tea and steamed milk, often served in a tall glass.", Price = "$4.00", Image = "/images/chai-latte.jpg" },
                
                new Product { Type = "canadian", Title = "Butter Tart", ShortDescription = "healthy and classic canadian dessert made", Description = "A classic Canadian dessert made with a flaky pastry shell", Price = "$6.00", Image = "/images/butter-tarts.png" },
                new Product { Type = "canadian", Title = "Nanaimo Bar", ShortDescription = "Wonderful sweet split in bars", Description = "A no-bake dessert bar that originated in Nanaimo, British Columbia, Canada.", Price = "$3.00", Image = "/images/nanaimo-bars.webp" },
                new Product { Type = "canadian", Title = "Maple Syrup Pie", ShortDescription = "Most known complement to use with breakfast foods", Description = "A delicious pie made with maple syrup, often served as a sweet treat or dessert.", Price = "$5.00", Image = "/images/maple-syrup.jpg" },
                
                new Product { Type = "sweet", Title = "Muffins", ShortDescription = "a simple small cake but still delicious by choice", Description = "A small, sweet baked good that is often enjoyed as a breakfast treat or snack.", Price = "$1.50", Image = "/images/muffins.jpg" },
                new Product { Type = "sweet", Title = "Brownies Pie", ShortDescription = "a traditional pie from United States", Description = "A delicious pie made with a rich and fudgy brownie base", Price = "$4.50", Image = "/images/brownies-pie.jpg" },
                new Product { Type = "sweet", Title = "Waffles", ShortDescription = "the smoothest food in our restaurant", Description = "A delicious and smooth mass made from a batter of flour, sugar, eggs, and butter, cooked in a waffle iron to create a crispy, golden-brown treat.", Price = "$6.00", Image = "/images/waffles.jpg" }
            };

            return Json(products);
        }
    }
}