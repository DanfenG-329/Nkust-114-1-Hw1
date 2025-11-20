using Microsoft.EntityFrameworkCore;

namespace LightRailApp
{
    public class LightRailDbContext : DbContext
    {
        // 對應到資料庫的 Table
        public DbSet<LightRailEntity> LightRailStats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 設定連線字串 (使用 LocalDB)
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=LightRailDb;Trusted_Connection=True;"
            );
        }
    }
}