using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testapi.Migrations
{
    /// <inheritdoc />
    public partial class superpower1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuperHeroId",
                table: "SuperPower",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuperPower_SuperHeroId",
                table: "SuperPower",
                column: "SuperHeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPower_SuperHeroes_SuperHeroId",
                table: "SuperPower",
                column: "SuperHeroId",
                principalTable: "SuperHeroes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPower_SuperHeroes_SuperHeroId",
                table: "SuperPower");

            migrationBuilder.DropIndex(
                name: "IX_SuperPower_SuperHeroId",
                table: "SuperPower");

            migrationBuilder.DropColumn(
                name: "SuperHeroId",
                table: "SuperPower");
        }
    }
}
