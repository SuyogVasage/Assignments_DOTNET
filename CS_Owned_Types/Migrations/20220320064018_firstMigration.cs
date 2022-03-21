using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS_Owned_Types.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress_HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress_Society = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress_Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress_Region_RegionId = table.Column<int>(type: "int", nullable: false),
                    CurrentAddress_Region_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress_Region_District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress_Region_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress_Region_CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Country_CurrentAddress_Region_CountryId",
                        column: x => x.CurrentAddress_Region_CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Society = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region_RegionId = table.Column<int>(type: "int", nullable: false),
                    Region_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region_District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region_CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Region_Country_Region_CountryId",
                        column: x => x.Region_CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Region_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CurrentAddress_Region_CountryId",
                table: "Persons",
                column: "CurrentAddress_Region_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_Region_CountryId",
                table: "Region",
                column: "Region_CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
