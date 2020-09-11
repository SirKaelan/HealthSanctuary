using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthSanctuary.Data.Migrations
{
    public partial class MakeMealsOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Meals_MealId",
                table: "Workouts");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Meals_MealId",
                table: "Workouts",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Meals_MealId",
                table: "Workouts");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Meals_MealId",
                table: "Workouts",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
