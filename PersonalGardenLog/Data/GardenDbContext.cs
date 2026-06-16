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
            
            // テスト用の初期データ（シードデータ）を注入
            modelBuilder.Entity<Plant>().HasData(
                new Plant { Id = 1, Name = "モンステラ", Species = "観葉植物", WateringIntervalDays = 7, LastWateredDate = System.DateTime.Now.AddDays(-6) },
                new Plant { Id = 2, Name = "バジル", Species = "ハーブ", WateringIntervalDays = 2, LastWateredDate = System.DateTime.Now.AddDays(-3) } // すでに水やり期限切れの状態
            );
        }
    }
}