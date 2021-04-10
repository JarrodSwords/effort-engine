using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarioRpg.Infrastructure.Write.Migrations
{
    public partial class CharacterTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_enemy",
                table: "character",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_non_player_character",
                table: "character",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_enemy",
                table: "character");

            migrationBuilder.DropColumn(
                name: "is_non_player_character",
                table: "character");
        }
    }
}
