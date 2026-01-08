using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightRailWeb.Models
{
    [Table("LightRailStats")]
    public class LightRailEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        //public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}