using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;
namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the discriminator for TPH inheritance          
            modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Person>("Person")
            .HasValue<Employee>("Employee");
        }

    }
}