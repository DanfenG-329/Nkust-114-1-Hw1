using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace LightRailApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 基本設定
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== 高雄輕軌資料匯入工具 ===");

            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "data.json");

            if (!File.Exists(jsonPath))
            {
                Console.WriteLine("錯誤：找不到 data.json 檔案！");
                return;
            }

            try
            {
                // 2. 讀取並反序列化 JSON
                string jsonString = File.ReadAllText(jsonPath);
                var rootData = JsonSerializer.Deserialize<RootObject>(jsonString);

                if (rootData?.data == null)
                {
                    Console.WriteLine("讀取失敗：資料為空");
                    return;
                }

                Console.WriteLine($"成功讀取到 {rootData.data.Count} 筆 JSON 資料。");

                // 3. 資料庫操作
                using (var db = new LightRailDbContext())
                {
                    // 確保資料庫存在 (這行在開發階段很有用，但正規做法是透過 Migration)
                    db.Database.EnsureCreated();

                    // 檢查是否已有資料，若有則詢問是否清空
                    if (db.LightRailStats.Any())
                    {
                        Console.Write("資料庫已有資料，是否清空重寫？(Y/N): ");
                        if (Console.ReadLine()?.ToUpper() == "Y")
                        {
                            db.Database.ExecuteSqlRaw("TRUNCATE TABLE LightRailStats");
                            Console.WriteLine("資料表已清空。");
                        }
                    }

                    // 4. 將 JSON 資料轉換為 Entity 並存入
                    // 如果資料庫是空的才寫入，避免重複
                    if (!db.LightRailStats.Any())
                    {
                        Console.WriteLine("正在寫入資料庫...");

                        var entities = rootData.data.Select(x => new LightRailEntity
                        {
                            Seq = x.Seq,
                            Year = x.Year,
                            Month = x.Month,
                            TotalVolume = x.TotalVolume,
                            DailyAvg = x.DailyAvg,
                            HolidayAvg = x.HolidayAvg,
                            PlatformSwipe = x.PlatformSwipe,
                            OnboardSwipe = x.OnboardSwipe,
                            QRCode = x.QRCode,
                            Note = x.Note
                        });

                        db.LightRailStats.AddRange(entities);
                        db.SaveChanges();
                        Console.WriteLine("資料寫入完成！");
                    }

                    // ==========================================
                    // 5. 完成的資料查找 (LINQ 查詢範例)
                    // ==========================================
                    Console.WriteLine("\n-------- 資料庫查詢示範 --------");

                    // 查詢 1: 找最新的一筆資料 (依照年、月排序)
                    // 注意：因為欄位是字串，排序上可能需要轉型，這裡簡單示範用 ID 倒序
                    var lastRecord = db.LightRailStats.OrderByDescending(x => x.Id).FirstOrDefault();
                    if (lastRecord != null)
                    {
                        Console.WriteLine($"最新資料: 民國{lastRecord.Year}年{lastRecord.Month}月, 總運量: {lastRecord.TotalVolume}");
                    }

                    // 查詢 2: 搜尋備註中有 "免費" 的月份
                    var freeRides = db.LightRailStats
                                      .Where(x => x.Note != null && x.Note.Contains("免費"))
                                      .ToList();

                    Console.WriteLine($"\n搜尋到 {freeRides.Count} 筆含有「免費」關鍵字的紀錄：");
                    foreach (var item in freeRides)
                    {
                        Console.WriteLine($" - {item.Year}/{item.Month}: {item.Note}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"發生錯誤: {ex.Message}");
            }

            Console.WriteLine("\n按任意鍵結束...");
            Console.ReadKey();
        }
    }
}