using KaohsiungLightRail.Data;
using KaohsiungLightRail.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Globalization;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("高雄輕軌資料匯入程式啟動...");

        // 1. 讀取 appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // 2. 建立資料庫連線選項
        var optionsBuilder = new DbContextOptionsBuilder<RailDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        // 3. 讀取 data.json
        Console.WriteLine("正在讀取 data.json...");
        string jsonData = File.ReadAllText("data.json");

        // 使用 JsonWrapper 反序列化
        var jsonWrapper = JsonConvert.DeserializeObject<JsonWrapper>(jsonData);
        var dtos = jsonWrapper.Data;

        Console.WriteLine($"成功讀取 {dtos.Count} 筆原始資料。");

        // 4. 資料清理與轉換 (ETL)
        Console.WriteLine("正在清理與轉換資料...");
        var entities = new List<LightRailData>();

        foreach (var dto in dtos)
        {
            var entity = new LightRailData
            {
                Seq = dto.Seq,
                Year = ParseInt(dto.Year) ?? 0, // 年和月應該要有值
                Month = ParseInt(dto.Month) ?? 0,
                TotalRidership = ParseInt(dto.TotalRidership),
                AvgDailyRidership = ParseInt(dto.AvgDailyRidership),
                AvgHolidayRidership = ParseInt(dto.AvgHolidayRidership),
                AvgDailyPlatformCard = ParseDecimal(dto.AvgDailyPlatformCard),
                AvgDailyOnBoardCard = ParseDecimal(dto.AvgDailyOnBoardCard),
                AvgDailyTicketMachine = ParseDecimal(dto.AvgDailyTicketMachine),
                AvgDailyFareAdjustment = ParseDecimal(dto.AvgDailyFareAdjustment),
                AvgDailyGroupTicket = ParseDecimal(dto.AvgDailyGroupTicket),
                AvgDailyManualTicket = ParseDecimal(dto.AvgDailyManualTicket),
                AvgDailyQRCode = ParseDecimal(dto.AvgDailyQRCode),
                Remarks = dto.Remarks
            };
            entities.Add(entity);
        }

        // 5. 將資料存入資料庫
        Console.WriteLine("正在將資料寫入 SQL Server...");
        using (var context = new RailDbContext(optionsBuilder.Options))
        {
            // 為防止資料重複寫入，我們先刪除舊資料
            // (EF Core 7.0+ 才支援 ExecuteDeleteAsync)
            // context.LightRailStats.ExecuteDelete(); 

            // 舊方法的替代方案 (清空資料表)
            context.LightRailStats.RemoveRange(context.LightRailStats);
            context.SaveChanges();

            // 一次性新增所有資料
            await context.LightRailStats.AddRangeAsync(entities);
            int count = await context.SaveChangesAsync();

            Console.WriteLine($"成功寫入 {count} 筆資料到資料庫！");
        }

        Console.WriteLine("程式執行完畢。");
    }

    // --- 輔助工具 (Helper Functions) ---

    // 處理 "1,234" 或 "5678" 或 ""
    private static int? ParseInt(string val)
    {
        if (string.IsNullOrWhiteSpace(val)) return null;

        // 移除逗號，然後嘗試解析
        if (int.TryParse(val.Replace(",", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
        {
            return result;
        }
        return null;
    }

    // 處理 "123.45" 或 ""
    private static decimal? ParseDecimal(string val)
    {
        if (string.IsNullOrWhiteSpace(val)) return null;

        // 移除逗號，然後嘗試解析
        if (decimal.TryParse(val.Replace(",", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
        {
            return result;
        }
        return null;
    }
}