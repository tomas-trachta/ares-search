using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AresSearchAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeadquartersModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionCode = table.Column<int>(type: "int", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictCode = table.Column<int>(type: "int", nullable: false),
                    TownCode = table.Column<int>(type: "int", nullable: false),
                    TownName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityDistrictCode = table.Column<int>(type: "int", nullable: false),
                    CityDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityDistrictPartCode = table.Column<int>(type: "int", nullable: false),
                    StreetCode = table.Column<int>(type: "int", nullable: false),
                    CityDistrictPartName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    TownPartCode = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    TownPartName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLocationCode = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    TextAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadquartersModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailingAddressModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingAddressModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadquartersId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailingAddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyInformation_HeadquartersModel_HeadquartersId",
                        column: x => x.HeadquartersId,
                        principalTable: "HeadquartersModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyInformation_MailingAddressModel_MailingAddressId",
                        column: x => x.MailingAddressId,
                        principalTable: "MailingAddressModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInformation_HeadquartersId",
                table: "CompanyInformation",
                column: "HeadquartersId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInformation_MailingAddressId",
                table: "CompanyInformation",
                column: "MailingAddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInformation");

            migrationBuilder.DropTable(
                name: "HeadquartersModel");

            migrationBuilder.DropTable(
                name: "MailingAddressModel");
        }
    }
}
