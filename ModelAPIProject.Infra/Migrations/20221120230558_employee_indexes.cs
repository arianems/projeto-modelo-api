using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenAPI.Infra.Migrations
{
    public partial class employee_indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_FirstName_Surname",
                table: "Employees",
                columns: new[] { "FirstName", "Surname" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_FirstName_Surname",
                table: "Employees");
        }
    }
}
