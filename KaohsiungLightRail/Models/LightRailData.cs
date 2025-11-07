// Models/LightRailData.cs
using System.ComponentModel.DataAnnotations;

namespace KaohsiungLightRail.Models
{
    // 這將成為資料庫中的 "LightRailStats" 資料表
    public class LightRailData
    {
        [Key]
        public int Id { get; set; } // 自動增長的主鍵

        public int Seq { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        // 使用可為 Null 的型別 (e.g., int?) 來處理 JSON 中的空字串
        public int? TotalRidership { get; set; }
        public int? AvgDailyRidership { get; set; }
        public int? AvgHolidayRidership { get; set; }
        public decimal? AvgDailyPlatformCard { get; set; }
        public decimal? AvgDailyOnBoardCard { get; set; }
        public decimal? AvgDailyTicketMachine { get; set; }
        public decimal? AvgDailyFareAdjustment { get; set; }
        public decimal? AvgDailyGroupTicket { get; set; }
        public decimal? AvgDailyManualTicket { get; set; }
        public decimal? AvgDailyQRCode { get; set; }
        public string Remarks { get; set; }
    }
}