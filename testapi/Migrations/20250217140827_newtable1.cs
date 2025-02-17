using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testapi.Migrations
{
    /// <inheritdoc />
    public partial class newtable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPower_SuperHeroes_SuperHeroId",
                table: "SuperPower");

            migrationBuilder.DropIndex(
                name: "IX_SuperPower_SuperHeroId",
                table: "SuperPower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "SuperHeroId",
                table: "SuperPower");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "SuperVillains",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperVillains",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "SuperVillains",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "SuperVillains",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SuperHeroName",
                table: "SuperPower",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperHeroes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SuperHeroes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SuperVillains_Name_FirstName_LastName_Place",
                table: "SuperVillains",
                columns: new[] { "Name", "FirstName", "LastName", "Place" });

            migrationBuilder.CreateIndex(
                name: "IX_SuperPower_SuperHeroName",
                table: "SuperPower",
                column: "SuperHeroName");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_Name",
                table: "SuperHeroes",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPower_SuperHeroes_SuperHeroName",
                table: "SuperPower",
                column: "SuperHeroName",
                principalTable: "SuperHeroes",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPower_SuperHeroes_SuperHeroName",
                table: "SuperPower");

            migrationBuilder.DropIndex(
                name: "IX_SuperVillains_Name_FirstName_LastName_Place",
                table: "SuperVillains");

            migrationBuilder.DropIndex(
                name: "IX_SuperPower_SuperHeroName",
                table: "SuperPower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes");

            migrationBuilder.DropIndex(
                name: "IX_SuperHeroes_Name",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "SuperHeroName",
                table: "SuperPower");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "SuperVillains",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperVillains",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "SuperVillains",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "SuperVillains",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "SuperHeroId",
                table: "SuperPower",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SuperHeroes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperHeroes",
                table: "SuperHeroes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPower_SuperHeroId",
                table: "SuperPower",
                column: "SuperHeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPower_SuperHeroes_SuperHeroId",
                table: "SuperPower",
                column: "SuperHeroId",
                principalTable: "SuperHeroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
