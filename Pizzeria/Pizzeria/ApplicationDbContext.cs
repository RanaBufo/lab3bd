using Microsoft.EntityFrameworkCore;
using Pizzeria.Models;

namespace Pizzeria
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Filling> Fillings { get; set; }
        public DbSet<Cocker> Cockers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Director> Derectors { get; set; }
    }
}
