using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TokenAPI.Infra.Migrations
{
    public partial class deleteusersv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [USERS]", true);
        }
    }
}
