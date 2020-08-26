using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthSanctuary.Data.Migrations
{
    public partial class AddOwnerToWorkouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Workouts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Workouts");
        }
    }
}
