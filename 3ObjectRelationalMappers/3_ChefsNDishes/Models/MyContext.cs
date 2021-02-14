using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    // The MyContext class represents a session with our MySQL database allowing us to query for our save data
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        // MAKE SURE TO ADD YOUR MODELS HERE
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}

    }
}