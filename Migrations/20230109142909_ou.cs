using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace NAMIS.Migrations
{
    public partial class ou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cadre = table.Column<string>(type: "varchar(200)", nullable: true),
                    GradeLevel = table.Column<string>(type: "varchar(50)", nullable: true),
                    StaffInPost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    NoDue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Approved = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DoneBy = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManPowers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManPowers");
        }
    }
}
