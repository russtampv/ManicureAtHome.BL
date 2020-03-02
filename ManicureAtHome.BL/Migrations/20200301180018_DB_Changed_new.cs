using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicureAtHome.BL.Migrations
{
    public partial class DB_Changed_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SoldServices_ClientId",
                table: "SoldServices");

            migrationBuilder.DropIndex(
                name: "IX_Records_ClientId",
                table: "Records");

            migrationBuilder.CreateIndex(
                name: "IX_SoldServices_ClientId",
                table: "SoldServices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_ClientId",
                table: "Records",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SoldServices_ClientId",
                table: "SoldServices");

            migrationBuilder.DropIndex(
                name: "IX_Records_ClientId",
                table: "Records");

            migrationBuilder.CreateIndex(
                name: "IX_SoldServices_ClientId",
                table: "SoldServices",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_ClientId",
                table: "Records",
                column: "ClientId",
                unique: true);
        }
    }
}
