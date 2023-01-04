using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace NAMIS.Migrations
{
    public partial class yiuo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET default_storage_engine=INNODB");
            migrationBuilder.AddColumn<string>(
                name: "RefNo",
                table: "Directives",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Refrences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RefNo = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refrences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Refrences");

            migrationBuilder.DropColumn(
                name: "RefNo",
                table: "Directives");
        }
    }
}
