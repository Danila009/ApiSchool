using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2_API.Migrations
{
    public partial class remdirdescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectorDescription",
                table: "Director");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Director",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Director");

            migrationBuilder.AddColumn<string>(
                name: "DirectorDescription",
                table: "Director",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
