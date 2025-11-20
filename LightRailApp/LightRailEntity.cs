using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightRailApp
{
    [Table("LightRailStats")] // 設定資料表名稱
    public class LightRailEntity
    {
        [Key] // 主鍵
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 自動遞增
        public int Id { get; set; }

        public int Seq { get; set; }

        [MaxLength(10)]
        public string? Year { get; set; }

        [MaxLength(10)]
        public string? Month { get; set; }

        [MaxLength(50)]
        public string? TotalVolume { get; set; }

        [MaxLength(50)]
        public string? DailyAvg { get; set; }

        [MaxLength(50)]
        public string? HolidayAvg { get; set; }

        [MaxLength(50)]
        public string? PlatformSwipe { get; set; }

        [MaxLength(50)]
        public string? OnboardSwipe { get; set; }

        [MaxLength(50)]
        public string? QRCode { get; set; }

        public string? Note { get; set; }
    }
}