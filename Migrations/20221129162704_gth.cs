using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace NAMIS.Migrations
{
    public partial class gth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    OfficerName = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Responsibility = table.Column<string>(type: "varchar(200)", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(5000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directives", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directives");
        }
    }
}
