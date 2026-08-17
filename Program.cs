using Microsoft.EntityFrameworkCore;
using NaboriousCoffee.Data;
using NaboriousCoffee.Models; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    
    context.Database.EnsureCreated();

    // Seed the database with initial data if it's empty
    if (!context.Coffees.Any())
    {
        context.Coffees.AddRange(

            // --- COFFEES ---

            new Coffee
            {
                Type = "coffee",
                Title = "Espresso",
                ShortDescription = "Strong and aromatic Italian coffee",
                Description = "A strong and bold coffee made by forcing hot water through finely-ground coffee beans.",
                Price = 3.50m,
                Image = "images/espresso.jpg"
            },
            new Coffee
            {
                Type = "coffee",
                Title = "Latte",
                ShortDescription = "Unique and decent creamy coffe drink",
                Description = "A creamy coffee made with espresso and steamed milk, topped with a small amount of foam.",
                Price = 4.00m,
                Image = "images/latte.jpg"
            },
            new Coffee
            {
                Type = "coffee",
                Title = "Cappuccino",
                ShortDescription = "A coffee drink made with steamed milk foam",
                Description = "A coffee drink made with espresso and steamed milk, topped with a layer of foam.",
                Price = 4.50m,
                Image = "images/cappucino.jpg"
            },
            new Coffee
            {
                Type = "coffee",
                Title = "Milkshake",
                ShortDescription = "Delicious creamy milk drink",
                Description = "A creamy milk-based drink made with ice cream and flavoring, often served in a tall glass.",
                Price = 5.50m,
                Image = "images/milkshake.jpg"
            },
            new Coffee
            {
                Type = "coffee",
                Title = "Macchiato",
                ShortDescription = "Exotic but delicious coffee with a shot of espresso",
                Description = "A coffee drink made with a shot of espresso and a small amount of steamed milk, often served in a small cup.",
                Price = 4.50m,
                Image = "images/macchiato.jpg"
            },
            new Coffee
            {
                Type = "coffee",
                Title = "Chai Latte",
                ShortDescription = "Fabulous coffee made with a tea and milk",
                Description = "A creamy coffee drink made with chai tea and steamed milk, often served in a tall glass.",
                Price = 4.00m,
                Image = "images/chai-latte.jpg"
            },

            // --- CANADIAN SWEETS ---

            new Coffee
            {
                Type = "canadian",
                Title = "Butter Tart",
                ShortDescription = "healthy and classic canadian dessert made",
                Description = "A classic Canadian dessert made with a flaky pastry shell",
                Price = 6.00m,
                Image = "images/butter-tarts.png"
            },
            new Coffee
            {
                Type = "canadian",
                Title = "Nanaimo Bar",
                ShortDescription = "Wonderful sweet split in bars",
                Description = "A no-bake dessert bar that originated in Nanaimo, British Columbia, Canada.",
                Price = 3.00m,
                Image = "images/nanaimo-bars.webp"
            },
            new Coffee
            {
                Type = "canadian",
                Title = "Maple Syrup Pie",
                ShortDescription = "Most known complement to use with breakfast foods",
                Description = "A delicious pie made with maple syrup, often served as a sweet treat or dessert.",
                Price = 5.00m,
                Image = "images/maple-syrup.jpg"
            },

            // --- OTHER SWEETS ---
            
            new Coffee
            {
                Type = "sweet",
                Title = "Muffins",
                ShortDescription = "a simple small cake but still delicious by choice",
                Description = "A small, sweet baked good that is often enjoyed as a breakfast treat or snack.",
                Price = 1.50m,
                Image = "images/muffins.jpg"
            },
            new Coffee
            {
                Type = "sweet",
                Title = "Brownies Pie",
                ShortDescription = "a traditional pie from United States",
                Description = "A delicious pie made with a rich and fudgy brownie base",
                Price = 4.50m,
                Image = "images/brownies-pie.jpg"
            },
            new Coffee
            {
                Type = "sweet",
                Title = "Waffles",
                ShortDescription = "the smoothest food in our restaurant",
                Description = "A delicious and smooth mass made from a batter of flour, sugar, eggs, and butter, cooked in a waffle iron to create a crispy, golden-brown treat.",
                Price = 6.00m,
                Image = "images/waffles.jpg"
            }
        );
        
        context.SaveChanges();
    }
}

app.Run();