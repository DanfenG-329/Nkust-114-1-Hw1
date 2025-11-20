using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightRailApp.Migrations
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
                    Year = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Month = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TotalVolume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DailyAvg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HolidayAvg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlatformSwipe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OnboardSwipe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QRCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
