using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NaboriousCoffee.Data;


namespace Naborious_Coffe_FS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context; // Database access via Entity Framework Core

        //Updated Constructor to accept AppDbContext for dependency injection
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // search for the Index action method to fetch data from the database
        public async Task<IActionResult> Index()
        {
            var coffees = await _context.Coffees.ToListAsync();
            return View(coffees); 
        }

        // This action method will be called by your JavaScript to fetch the products in JSON format
        [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var coffees = await _context.Coffees.ToListAsync();

        // Convert with the desired price format
        var products = coffees.Select(c => new {
            Id = c.Id,
            Type = c.Type,
            Title = c.Title,
            ShortDescription = c.ShortDescription,
            Description = c.Description,
            // 3.5 --> 3.50
            Price = $"${c.Price.ToString("F2", System.Globalization.CultureInfo.InvariantCulture)}",
            Image = c.Image
    }).ToList();

    return Json(products);
}
    }
}