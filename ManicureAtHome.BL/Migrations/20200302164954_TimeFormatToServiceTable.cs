using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicureAtHome.BL.Migrations
{
    public partial class TimeFormatToServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalTime",
                table: "SoldServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "SoldServices");
        }
    }
}
