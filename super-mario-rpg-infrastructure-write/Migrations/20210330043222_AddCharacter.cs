using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarioRpg.Infrastructure.Write.Migrations
{
    public partial class AddCharacter : Migration
    {
        #region Protected Interface

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Characters"
            );
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Characters",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    Name = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Characters", x => x.Id); }
            );
        }

        #endregion
    }
}
