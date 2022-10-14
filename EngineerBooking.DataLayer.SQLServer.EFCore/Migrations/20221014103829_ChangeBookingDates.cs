using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineerBooking.DataLayer.SQLServer.EFCore.Migrations
{
    public partial class ChangeBookingDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TimeSlots_TimeSlotId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TimeSlotId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Bookings",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Bookings",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeSlotId",
                table: "Bookings",
                column: "TimeSlotId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TimeSlots_TimeSlotId",
                table: "Bookings",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id");
        }
    }
}
