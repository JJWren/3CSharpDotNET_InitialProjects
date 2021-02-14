using Microsoft.EntityFrameworkCore;

namespace CSharpExam.Models
{
    // The MyContext class represents a session with our MySQL database allowing us to query for our save data
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        // MAKE SURE TO ADD YOUR MODELS HERE
        public DbSet<User> Users { get; set;}
        public DbSet<Idea> Ideas { get; set;}
        public DbSet<Like> Likes { get; set;}
    }
}