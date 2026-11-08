using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication57.Models;

namespace WebApplication57.Data // database ==> tables
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //table 1 
        public DbSet<Category> categories { get; set; }


        // table 2
        public DbSet<Manager> managers { get; set; }

        //table 3

        public DbSet<Employee> employees { get; set; }

        public DbSet<Order> orders { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<SupplyNew> supplyNews { get; set; }
        public DbSet<CategoryNew> categoryNews { get; set; }
        public DbSet<OfferNew> OfferNews { get; set; }


    }
}
