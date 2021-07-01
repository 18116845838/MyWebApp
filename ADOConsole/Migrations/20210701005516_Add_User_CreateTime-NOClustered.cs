using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADOConsole.Migrations
{
    public partial class Add_User_CreateTimeNOClustered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTiem",
                table: "Register",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Register_CreateTiem",
                table: "Register",
                column: "CreateTiem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Register_CreateTiem",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "CreateTiem",
                table: "Register");
        }
    }
}
