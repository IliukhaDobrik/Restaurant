using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class NewChangesForTrigger2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Places_PlaceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PlaceId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_PlaceId",
                table: "Places",
                column: "PlaceId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_PlaceId",
                table: "Places");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlaceId",
                table: "Users",
                column: "PlaceId",
                unique: true,
                filter: "[PlaceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Places_PlaceId",
                table: "Users",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
