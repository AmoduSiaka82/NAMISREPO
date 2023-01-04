﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NAMIS.Migrations
{
    public partial class rofDa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfResumetion",
                table: "StaffPosting",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfResumetion",
                table: "StaffPosting");
        }
    }
}
