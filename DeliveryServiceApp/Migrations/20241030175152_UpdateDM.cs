using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Deliveries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Deliveries",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
