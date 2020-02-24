using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManicureAtHome.BL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    InstagrammAddress = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    IsSupplier = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    IsDelivery = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfReceipt = table.Column<DateTime>(nullable: false),
                    DateOfReceipt = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    TimeToWork = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldServices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    manicureName = table.Column<string>(maxLength: 350, nullable: true),
                    Worker = table.Column<string>(maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    WorkTime = table.Column<DateTime>(nullable: false),
                    RecordToSpecialistId = table.Column<int>(nullable: true),
                    SoldServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Records_RecordToSpecialistId",
                        column: x => x.RecordToSpecialistId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_SoldServices_SoldServiceId",
                        column: x => x.SoldServiceId,
                        principalTable: "SoldServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WareHouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductCount = table.Column<int>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    SoldServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WareHouse_SoldServices_SoldServiceId",
                        column: x => x.SoldServiceId,
                        principalTable: "SoldServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WareHouse_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materialName = table.Column<string>(maxLength: 200, nullable: true),
                    Maker = table.Column<string>(maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    QualityLevel = table.Column<int>(nullable: true),
                    MadeIn = table.Column<string>(maxLength: 200, nullable: true),
                    Count = table.Column<int>(nullable: false),
                    WareHouseId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_WareHouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "WareHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ContactId",
                table: "Clients",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ServiceId",
                table: "Materials",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_WareHouseId",
                table: "Materials",
                column: "WareHouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_ClientId",
                table: "Records",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_RecordToSpecialistId",
                table: "Services",
                column: "RecordToSpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SoldServiceId",
                table: "Services",
                column: "SoldServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldServices_ClientId",
                table: "SoldServices",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ContactId",
                table: "Suppliers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_SoldServiceId",
                table: "WareHouse",
                column: "SoldServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WareHouse_SupplierId",
                table: "WareHouse",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "WareHouse");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "SoldServices");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
