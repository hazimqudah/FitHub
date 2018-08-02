using Microsoft.EntityFrameworkCore.Migrations;

namespace FitHub.Migrations
{
    public partial class AddMGToExerciseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExMgID",
                table: "Exercises",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExMgID",
                table: "Exercises");
        }
    }
}
