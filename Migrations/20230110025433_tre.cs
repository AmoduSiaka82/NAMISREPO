using Microsoft.EntityFrameworkCore.Migrations;

namespace NAMIS.Migrations
{
    public partial class tre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecieverId",
                table: "ManPowers",
                type: "varchar(150)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecieverId",
                table: "ManPowers");
        }
    }
}
