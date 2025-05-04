using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingWebsiteMVC.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyInDishIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_IngredientId",
                table: "DishIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_IngredientId",
                table: "DishIngredients",
                column: "IngredientId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
