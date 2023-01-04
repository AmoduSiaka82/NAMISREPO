using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace NAMIS.Migrations
{
    public partial class rttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YourName",
                table: "PersonelFile",
                type: "varchar(1000)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dispositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "varchar(500)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(500)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(500)", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Rank = table.Column<string>(type: "varchar(150)", nullable: false),
                    OStep = table.Column<string>(type: "varchar(150)", nullable: false),
                    NStep = table.Column<string>(type: "varchar(150)", nullable: false),
                    OldSal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    NewSal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StateOfOrigin = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateOfFirstAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateOfCurrentAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    StationName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VariationAdvices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "varchar(500)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(500)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(500)", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Rank = table.Column<string>(type: "varchar(150)", nullable: false),
                    Step = table.Column<string>(type: "varchar(150)", nullable: false),
                    OldSal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    NewSal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AmtOfVariation = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Reasons = table.Column<string>(type: "varchar(150)", nullable: false),
                    EffDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remark = table.Column<string>(type: "varchar(2000)", nullable: false),
                    CurrentAppointment = table.Column<string>(type: "varchar(150)", nullable: false),
                    Authority = table.Column<string>(type: "varchar(2000)", nullable: false),
                    StationName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariationAdvices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispositions");

            migrationBuilder.DropTable(
                name: "VariationAdvices");

            migrationBuilder.DropColumn(
                name: "YourName",
                table: "PersonelFile");
        }
    }
}
