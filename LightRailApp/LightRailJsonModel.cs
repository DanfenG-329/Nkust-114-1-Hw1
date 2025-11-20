using System.Text.Json.Serialization;

namespace LightRailApp
{
    // JSON 的最外層結構 (因為 data.json 有包一層 root)
    public class RootObject
    {
        public bool success { get; set; }
        public List<LightRailJsonItem>? data { get; set; }
    }

    // 對應 data 陣列裡的每一筆資料
    public class LightRailJsonItem
    {
        public int Seq { get; set; }

        [JsonPropertyName("年")]
        public string? Year { get; set; }

        [JsonPropertyName("月")]
        public string? Month { get; set; }

        [JsonPropertyName("總運量")]
        public string? TotalVolume { get; set; }

        [JsonPropertyName("日均運量")]
        public string? DailyAvg { get; set; }

        [JsonPropertyName("假日均運量")]
        public string? HolidayAvg { get; set; }

        [JsonPropertyName("月台上刷卡日均筆數")]
        public string? PlatformSwipe { get; set; }

        [JsonPropertyName("車上刷卡日均筆數")]
        public string? OnboardSwipe { get; set; }

        [JsonPropertyName("QR-CODE日均筆數")]
        public string? QRCode { get; set; }

        [JsonPropertyName("備註")]
        public string? Note { get; set; }
    }
}