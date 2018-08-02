using Microsoft.EntityFrameworkCore.Migrations;

namespace FitHub.Migrations
{
    public partial class CreateMGKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExMgID",
                table: "Exercises",
                column: "ExMgID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_MuscleGroups_ExMgID",
                table: "Exercises",
                column: "ExMgID",
                principalTable: "MuscleGroups",
                principalColumn: "MgId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_MuscleGroups_ExMgID",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ExMgID",
                table: "Exercises");
        }
    }
}
