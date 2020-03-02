using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicureAtHome.BL.Migrations
{
    public partial class Update_ServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_WareHouse_WareHouseId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_WareHouse_SoldServices_SoldServiceId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_WareHouse_SoldServiceId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_Materials_WareHouseId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SoldServiceId",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "TimeToWork",
                table: "SoldServices");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "SoldServices",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "manicureName",
                table: "Services",
                newName: "ManicureName");

            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "WareHouse",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "WareHouse",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "WareHouse",
                nullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "WorkTime",
                table: "Services",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "DopInfo",
                table: "Materials",
                maxLength: 700,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_MaterialId",
                table: "WareHouse",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouse_Materials_MaterialId",
                table: "WareHouse",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WareHouse_Materials_MaterialId",
                table: "WareHouse");

            migrationBuilder.DropIndex(
                name: "IX_WareHouse_MaterialId",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "WareHouse");

            migrationBuilder.DropColumn(
                name: "DopInfo",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "SoldServices",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ManicureName",
                table: "Services",
                newName: "manicureName");

            migrationBuilder.AlterColumn<string>(
                name: "ProductType",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "WareHouse",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoldServiceId",
                table: "WareHouse",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeToWork",
                table: "SoldServices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "WorkTime",
                table: "Services",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WareHouseId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_SoldServiceId",
                table: "WareHouse",
                column: "SoldServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_WareHouseId",
                table: "Materials",
                column: "WareHouseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_WareHouse_WareHouseId",
                table: "Materials",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WareHouse_SoldServices_SoldServiceId",
                table: "WareHouse",
                column: "SoldServiceId",
                principalTable: "SoldServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
