using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TokenAPI.Infra.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("659e6ad1-13ac-4c3a-a7b7-db810d20f990"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5e1498fc-e8f0-4c62-a0df-ab94267c94ba"), "Human Resources" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("5e1498fc-e8f0-4c62-a0df-ab94267c94ba"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("659e6ad1-13ac-4c3a-a7b7-db810d20f990"), "Human Resources" });
        }
    }
}
