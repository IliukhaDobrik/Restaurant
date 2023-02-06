using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class RefactoringEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDishes_Menu_DishId",
                table: "UserDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDishes_Users_UserId",
                table: "UserDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Places_PlaceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PlaceId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDishes",
                table: "UserDishes");

            migrationBuilder.DropColumn(
                name: "DateOfReservation",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Places");

            migrationBuilder.RenameTable(
                name: "UserDishes",
                newName: "Basket");

            migrationBuilder.RenameIndex(
                name: "IX_UserDishes_UserId",
                table: "Basket",
                newName: "IX_Basket_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserDishes_DishId",
                table: "Basket",
                newName: "IX_Basket_DishId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlaceId",
                table: "Places",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfReservation",
                table: "Places",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Places",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DishId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDishesId",
                table: "Basket",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "UserDishesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_UserId",
                table: "Places",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Menu_DishId",
                table: "Basket",
                column: "DishId",
                principalTable: "Menu",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Users_UserId",
                table: "Basket",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_UserId",
                table: "Places",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Menu_DishId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Users_UserId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_UserId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Places_UserId",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "DateOfReservation",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Places");

            migrationBuilder.RenameTable(
                name: "Basket",
                newName: "UserDishes");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_UserId",
                table: "UserDishes",
                newName: "IX_UserDishes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Basket_DishId",
                table: "UserDishes",
                newName: "IX_UserDishes_DishId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfReservation",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlaceId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PlaceId",
                table: "Places",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Places",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "DishId",
                table: "Menu",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDishesId",
                table: "UserDishes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDishes",
                table: "UserDishes",
                column: "UserDishesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PlaceId",
                table: "Users",
                column: "PlaceId",
                unique: true,
                filter: "[PlaceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDishes_Menu_DishId",
                table: "UserDishes",
                column: "DishId",
                principalTable: "Menu",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDishes_Users_UserId",
                table: "UserDishes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

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
