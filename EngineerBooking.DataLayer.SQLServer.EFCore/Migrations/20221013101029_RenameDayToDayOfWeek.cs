using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Migrations
{
    public partial class RenameDayToDayOfWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Day",
                table: "TimeSlots",
                newName: "DayOfWeek");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "TimeSlots",
                newName: "Day");
        }
    }
}
