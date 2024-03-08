using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_DeliveryDetails_DeliveryDetailsDeliveryId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryDetailsDeliveryId",
                table: "Carts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_DeliveryDetails_DeliveryDetailsDeliveryId",
                table: "Carts",
                column: "DeliveryDetailsDeliveryId",
                principalTable: "DeliveryDetails",
                principalColumn: "DeliveryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_DeliveryDetails_DeliveryDetailsDeliveryId",
                table: "Carts");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryDetailsDeliveryId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_DeliveryDetails_DeliveryDetailsDeliveryId",
                table: "Carts",
                column: "DeliveryDetailsDeliveryId",
                principalTable: "DeliveryDetails",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
