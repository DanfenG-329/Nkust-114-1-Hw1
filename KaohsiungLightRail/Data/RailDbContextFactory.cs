// Data/RailDbContextFactory.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace KaohsiungLightRail.Data
{
    /*
     * 這是一個「設計階段工廠」，專門給 EF Core 工具 (像 Add-Migration) 使用的。
     * 當 EF Core 工具需要 DbContext 時，它會來找這個類別。
     * 它會手動讀取 appsettings.json 並設定連線字串。
     */
    public class RailDbContextFactory : IDesignTimeDbContextFactory<RailDbContext>
    {
        public RailDbContext CreateDbContext(string[] args)
        {
            // 建立設定檔建構器
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 建立 DbContext 選項建構器
            var optionsBuilder = new DbContextOptionsBuilder<RailDbContext>();

            // 從 appsettings.json 讀取連線字String
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 告訴選項建構器我們要使用 SQL Server，並傳入連線字串
            optionsBuilder.UseSqlServer(connectionString);

            // 建立並回傳 DbContext
            return new RailDbContext(optionsBuilder.Options);
        }
    }
}