using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TokenAPI.Infra.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9deb80b1-809b-4a82-9a1c-e8a524971941"), "Human Resources" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9deb80b1-809b-4a82-9a1c-e8a524971941"));
        }
    }
}
