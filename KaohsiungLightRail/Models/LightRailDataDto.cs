// Models/LightRailDataDto.cs
using Newtonsoft.Json;

namespace KaohsiungLightRail.Models
{
    // 這是 JSON 陣列中每個物件的結構
    public class LightRailDataDto
    {
        [JsonProperty("Seq")]
        public int Seq { get; set; }

        [JsonProperty("年")]
        public string Year { get; set; }

        [JsonProperty("月")]
        public string Month { get; set; }

        [JsonProperty("總運量")]
        public string TotalRidership { get; set; }

        [JsonProperty("日均運量")]
        public string AvgDailyRidership { get; set; }

        [JsonProperty("假日均運量")]
        public string AvgHolidayRidership { get; set; }

        [JsonProperty("月台上刷卡日均筆數")]
        public string AvgDailyPlatformCard { get; set; }

        [JsonProperty("車上刷卡日均筆數")]
        public string AvgDailyOnBoardCard { get; set; }

        [JsonProperty("售票機日均筆數")]
        public string AvgDailyTicketMachine { get; set; }

        [JsonProperty("補票日均筆數")]
        public string AvgDailyFareAdjustment { get; set; }

        [JsonProperty("團體票日均筆數")]
        public string AvgDailyGroupTicket { get; set; }

        [JsonProperty("人工售票日均筆數")]
        public string AvgDailyManualTicket { get; set; }

        [JsonProperty("QR-CODE日均筆數")]
        public string AvgDailyQRCode { get; set; }

        [JsonProperty("備註")]
        public string Remarks { get; set; }
    }

    // 這是最外層 JSON 結構的包裝類別
    public class JsonWrapper
    {
        [JsonProperty("data")]
        public List<LightRailDataDto> Data { get; set; }
    }
}