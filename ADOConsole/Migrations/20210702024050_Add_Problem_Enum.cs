using Microsoft.EntityFrameworkCore.Migrations;

namespace ADOConsole.Migrations
{
    public partial class Add_Problem_Enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_ProblemStatuses_ProblemStatusID",
                table: "Problems");

            migrationBuilder.DropTable(
                name: "ProblemStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ProblemStatusID",
                table: "Problems");

            migrationBuilder.AddColumn<int>(
                name: "ProblemStrtus",
                table: "Problems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemStrtus",
                table: "Problems");

            migrationBuilder.CreateTable(
                name: "ProblemStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HaveReward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToAssistInThe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Withdrawn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ProblemStatusID",
                table: "Problems",
                column: "ProblemStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_ProblemStatuses_ProblemStatusID",
                table: "Problems",
                column: "ProblemStatusID",
                principalTable: "ProblemStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
