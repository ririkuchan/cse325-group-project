using Microsoft.EntityFrameworkCore;
using PersonalGardenLog.Models;

namespace PersonalGardenLog.Data
{
    public class GardenDbContext : DbContext
    {
        public GardenDbContext(DbContextOptions<GardenDbContext> options) : base(options) { }

        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed data in English
            modelBuilder.Entity<Plant>().HasData(
                new Plant 
                { 
                    Id = 1, 
                    Name = "Monstera", 
                    Species = "Houseplant", 
                    WateringIntervalDays = 7, 
                    LastWateredDate = System.DateTime.Now.AddDays(-6) 
                },
                new Plant 
                { 
                    Id = 2, 
                    Name = "Basil", 
                    Species = "Herb", 
                    WateringIntervalDays = 2, 
                    LastWateredDate = System.DateTime.Now.AddDays(-3) // Already overdue
                }
            );
        }
    }
}