using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSSQLWebAPI.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "emil",
                table: "User",
                newName: "email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "User",
                newName: "emil");
        }
    }
}
