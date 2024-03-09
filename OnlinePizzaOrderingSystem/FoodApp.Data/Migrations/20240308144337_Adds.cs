using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Adds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_Users_CustomerUserID",
                table: "OrderSummaries");

            migrationBuilder.RenameColumn(
                name: "CustomerUserID",
                table: "OrderSummaries",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSummaries_CustomerUserID",
                table: "OrderSummaries",
                newName: "IX_OrderSummaries_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "OrderSummaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderSummaries_CartId",
                table: "OrderSummaries",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_Carts_CartId",
                table: "OrderSummaries",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_Users_CustomerId",
                table: "OrderSummaries",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_Carts_CartId",
                table: "OrderSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_Users_CustomerId",
                table: "OrderSummaries");

            migrationBuilder.DropIndex(
                name: "IX_OrderSummaries_CartId",
                table: "OrderSummaries");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "OrderSummaries");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "OrderSummaries",
                newName: "CustomerUserID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderSummaries_CustomerId",
                table: "OrderSummaries",
                newName: "IX_OrderSummaries_CustomerUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_Users_CustomerUserID",
                table: "OrderSummaries",
                column: "CustomerUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
