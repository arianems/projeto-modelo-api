using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TokenAPI.Infra.Migrations
{
    public partial class userentityv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeID",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_Id",
                table: "Users",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
