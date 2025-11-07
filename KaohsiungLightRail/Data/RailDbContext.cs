// Data/RailDbContext.cs
using KaohsiungLightRail.Models;
using Microsoft.EntityFrameworkCore;

namespace KaohsiungLightRail.Data
{
    public class RailDbContext : DbContext
    {
        // 告訴 EF Core，我們有一個 LightRailData 模型，
        // 它將對應到資料庫中的 "LightRailStats" 資料表
        public DbSet<LightRailData> LightRailStats { get; set; }

        public RailDbContext(DbContextOptions<RailDbContext> options) : base(options)
        {
        }
    }
}