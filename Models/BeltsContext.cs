using Microsoft.EntityFrameworkCore;
 
namespace Assignment.Models
{
    public class BeltsContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BeltsContext(DbContextOptions<BeltsContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Belt> Belts { get; set; }
        public DbSet<Category> Categories {get; set;}
        
    }
}