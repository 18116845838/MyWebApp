using Microsoft.EntityFrameworkCore.Migrations;

namespace ADOConsole.Migrations
{
    public partial class Add_User_CreateTime_OnCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateTiem",
                table: "Register",
                newName: "CreateTime");

            migrationBuilder.RenameIndex(
                name: "IX_Register_CreateTiem",
                table: "Register",
                newName: "IX_Register_CreateTime");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CreateTime",
                table: "Register",
                sql: "CreateTime>'2000-1-1'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CreateTime",
                table: "Register");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Register",
                newName: "CreateTiem");

            migrationBuilder.RenameIndex(
                name: "IX_Register_CreateTime",
                table: "Register",
                newName: "IX_Register_CreateTiem");
        }
    }
}
