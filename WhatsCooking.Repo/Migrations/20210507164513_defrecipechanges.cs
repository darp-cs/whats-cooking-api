using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsCooking.Repo.Migrations
{
    public partial class defrecipechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstimatedCookingTime",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IngredientsList",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGlutenFree",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVegan",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "EstimatedCookingTime",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientsList",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsGlutenFree",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsVegan",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });
        }
    }
}
