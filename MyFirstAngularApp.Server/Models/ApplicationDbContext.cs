using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MyFirstAngularApp.Server.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<SubService> SubServices { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship between Service and SubService
            modelBuilder.Entity<SubService>()
                .HasOne(s => s.Service)
                .WithMany(s => s.SubServices)
                .HasForeignKey(s => s.ServiceID);
        }
    }

}
