using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class orderstatusnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_DeliveryDetails_DeliveryDetailsDeliveryId",
                table: "OrderSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_OrderPayments_PaymentId",
                table: "OrderSummaries");

            migrationBuilder.RenameColumn(
                name: "calories",
                table: "MenuItems",
                newName: "Calories");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "OrderSummaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryDetailsDeliveryId",
                table: "OrderSummaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_DeliveryDetails_DeliveryDetailsDeliveryId",
                table: "OrderSummaries",
                column: "DeliveryDetailsDeliveryId",
                principalTable: "DeliveryDetails",
                principalColumn: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_OrderPayments_PaymentId",
                table: "OrderSummaries",
                column: "PaymentId",
                principalTable: "OrderPayments",
                principalColumn: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_DeliveryDetails_DeliveryDetailsDeliveryId",
                table: "OrderSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderSummaries_OrderPayments_PaymentId",
                table: "OrderSummaries");

            migrationBuilder.RenameColumn(
                name: "Calories",
                table: "MenuItems",
                newName: "calories");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "OrderSummaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryDetailsDeliveryId",
                table: "OrderSummaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_DeliveryDetails_DeliveryDetailsDeliveryId",
                table: "OrderSummaries",
                column: "DeliveryDetailsDeliveryId",
                principalTable: "DeliveryDetails",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSummaries_OrderPayments_PaymentId",
                table: "OrderSummaries",
                column: "PaymentId",
                principalTable: "OrderPayments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
