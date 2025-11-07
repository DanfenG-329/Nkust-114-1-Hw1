using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaohsiungLightRail.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LightRailStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seq = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    TotalRidership = table.Column<int>(type: "int", nullable: true),
                    AvgDailyRidership = table.Column<int>(type: "int", nullable: true),
                    AvgHolidayRidership = table.Column<int>(type: "int", nullable: true),
                    AvgDailyPlatformCard = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AvgDailyOnBoardCard = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AvgDailyTicketMachine = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AvgDailyFareAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AvgDailyGroupTicket = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AvgDailyManualTicket = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AvgDailyQRCode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightRailStats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LightRailStats");
        }
    }
}
