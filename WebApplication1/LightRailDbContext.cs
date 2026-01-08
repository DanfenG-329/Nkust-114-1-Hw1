using Microsoft.EntityFrameworkCore;
using LightRailWeb.Models;

namespace LightRailWeb.Data
{
    public class LightRailDbContext : DbContext
    {
        // 建構函式：讓系統可以注入連線設定
        public LightRailDbContext(DbContextOptions<LightRailDbContext> options)
            : base(options)
        {
        }

        public DbSet<LightRailEntity> LightRailStats { get; set; }
    }
}