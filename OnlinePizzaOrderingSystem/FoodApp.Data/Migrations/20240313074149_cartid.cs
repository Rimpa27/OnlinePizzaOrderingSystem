using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class cartid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Users");
        }
    }
}
