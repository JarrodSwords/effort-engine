using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarioRpg.Infrastructure.Write.Migrations
{
    public partial class AlterStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_character_combat_stats_combat_stats_id",
                table: "character");

            migrationBuilder.DropPrimaryKey(
                name: "pk_combat_stats",
                table: "combat_stats");

            migrationBuilder.RenameTable(
                name: "combat_stats",
                newName: "statistics");

            migrationBuilder.RenameColumn(
                name: "combat_stats_id",
                table: "character",
                newName: "statistics_id");

            migrationBuilder.RenameIndex(
                name: "ix_character_combat_stats_id",
                table: "character",
                newName: "ix_character_statistics_id");

            migrationBuilder.AlterColumn<short>(
                name: "hit_points",
                table: "statistics",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "pk_statistics",
                table: "statistics",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_character_statistics_statistics_id",
                table: "character",
                column: "statistics_id",
                principalTable: "statistics",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_character_statistics_statistics_id",
                table: "character");

            migrationBuilder.DropPrimaryKey(
                name: "pk_statistics",
                table: "statistics");

            migrationBuilder.RenameTable(
                name: "statistics",
                newName: "combat_stats");

            migrationBuilder.RenameColumn(
                name: "statistics_id",
                table: "character",
                newName: "combat_stats_id");

            migrationBuilder.RenameIndex(
                name: "ix_character_statistics_id",
                table: "character",
                newName: "ix_character_combat_stats_id");

            migrationBuilder.AlterColumn<int>(
                name: "hit_points",
                table: "combat_stats",
                type: "integer",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddPrimaryKey(
                name: "pk_combat_stats",
                table: "combat_stats",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_character_combat_stats_combat_stats_id",
                table: "character",
                column: "combat_stats_id",
                principalTable: "combat_stats",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
