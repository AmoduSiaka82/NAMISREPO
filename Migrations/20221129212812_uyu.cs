using Microsoft.EntityFrameworkCore.Migrations;

namespace NAMIS.Migrations
{
    public partial class uyu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Act",
                table: "Directives",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SprpNo",
                table: "Directives",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Directives",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Act",
                table: "Directives");

            migrationBuilder.DropColumn(
                name: "SprpNo",
                table: "Directives");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Directives");
        }
    }
}
