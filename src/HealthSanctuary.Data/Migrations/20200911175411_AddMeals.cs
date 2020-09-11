using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthSanctuary.Data.Migrations
{
    public partial class AddMeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Workouts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Exercises",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Exercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Servings = table.Column<int>(nullable: false),
                    KCal = table.Column<double>(nullable: false),
                    ReadyIn = table.Column<TimeSpan>(nullable: false),
                    AddedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_MealId",
                table: "Workouts",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Meals_MealId",
                table: "Workouts",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Meals_MealId",
                table: "Workouts");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_MealId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Exercises");
        }
    }
}
