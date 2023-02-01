using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class RemoveSomeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDishes_UserId_DishId",
                table: "UserDishes");

            migrationBuilder.CreateIndex(
                name: "IX_UserDishes_UserId",
                table: "UserDishes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDishes_UserId",
                table: "UserDishes");

            migrationBuilder.CreateIndex(
                name: "IX_UserDishes_UserId_DishId",
                table: "UserDishes",
                columns: new[] { "UserId", "DishId" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [DishId] IS NOT NULL");
        }
    }
}
