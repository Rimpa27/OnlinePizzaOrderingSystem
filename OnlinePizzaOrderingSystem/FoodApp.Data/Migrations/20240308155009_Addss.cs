using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_Users_CustomerId",
                table: "OrderSummaries");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "OrderSummaries",
                newName: "CustomerUserID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSummaries_CustomerId",
                table: "OrderSummaries",
                newName: "IX_OrderSummaries_CustomerUserID");

            migrationBuilder.AddColumn<int>(
                name: "CartItemId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CartItemPrice",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CartItemQuantity",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CartItemId",
                table: "OrderItems",
                column: "CartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_CartItems_CartItemId",
                table: "OrderItems",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "CartItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_Users_CustomerUserID",
                table: "OrderSummaries",
                column: "CustomerUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_CartItems_CartItemId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_Users_CustomerUserID",
                table: "OrderSummaries");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CartItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CartItemPrice",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CartItemQuantity",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "CustomerUserID",
                table: "OrderSummaries",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSummaries_CustomerUserID",
                table: "OrderSummaries",
                newName: "IX_OrderSummaries_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_Users_CustomerId",
                table: "OrderSummaries",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
