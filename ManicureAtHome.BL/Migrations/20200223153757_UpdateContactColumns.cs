using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicureAtHome.BL.Migrations
{
    public partial class UpdateContactColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Contacts",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string)
                );

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_materialName",
                table: "Materials",
                column: "materialName");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_FirstName_LastName",
                table: "Contacts",
                columns: new[] { "FirstName", "LastName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Materials_materialName",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_FirstName_LastName",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
