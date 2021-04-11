using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarioRpg.Infrastructure.Write.Migrations
{
    public partial class CreateCharacterAndCombatStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "combat_stats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    attack = table.Column<short>(type: "smallint", nullable: false),
                    defense = table.Column<short>(type: "smallint", nullable: false),
                    evade = table.Column<decimal>(type: "numeric", nullable: true),
                    flower_points = table.Column<byte>(type: "smallint", nullable: true),
                    hit_points = table.Column<int>(type: "integer", nullable: false),
                    magic_attack = table.Column<short>(type: "smallint", nullable: false),
                    magic_defense = table.Column<short>(type: "smallint", nullable: false),
                    magic_evade = table.Column<decimal>(type: "numeric", nullable: true),
                    speed = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_combat_stats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "character",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    combat_stats_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_enemy = table.Column<bool>(type: "boolean", nullable: false),
                    is_non_player_character = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_character", x => x.id);
                    table.ForeignKey(
                        name: "fk_character_combat_stats_combat_stats_id",
                        column: x => x.combat_stats_id,
                        principalTable: "combat_stats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_character_combat_stats_id",
                table: "character",
                column: "combat_stats_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "character");

            migrationBuilder.DropTable(
                name: "combat_stats");
        }
    }
}
