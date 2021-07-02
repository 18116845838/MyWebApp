using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ADOConsole.Migrations
{
    public partial class Add_Problem_ProblemStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProblemStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HaveReward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Withdrawn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToAssistInThe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProblemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemStatuses_Problems_ProblemID",
                        column: x => x.ProblemID,
                        principalTable: "Problems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemStatuses_ProblemID",
                table: "ProblemStatuses",
                column: "ProblemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemStatuses");

            migrationBuilder.DropTable(
                name: "Problems");
        }
    }
}
