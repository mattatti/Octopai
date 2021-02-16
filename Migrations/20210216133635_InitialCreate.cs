using Microsoft.EntityFrameworkCore.Migrations;

namespace Octopai.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarServices",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    ServiceStartDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ServiceEndDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    NetHours = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServices", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(6)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhoneNumber1 = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber2 = table.Column<int>(type: "int", nullable: false),
                    LastModifiedDate = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarServices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
