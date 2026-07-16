using Microsoft.EntityFrameworkCore;
using NaboriousCoffee.Models;

namespace NaboriousCoffee.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coffee> Coffees { get; set; }
    }
}      
