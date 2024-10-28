using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DeliveryServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class NewDeliveryServiceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksToDelivery_Book_BookId",
                table: "BooksToDelivery");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BooksToDelivery",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksToDelivery_BookId",
                table: "BooksToDelivery",
                newName: "IX_BooksToDelivery_OrderId");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuantityOfBooks = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksToDelivery_Orders_OrderId",
                table: "BooksToDelivery",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksToDelivery_Orders_OrderId",
                table: "BooksToDelivery");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "BooksToDelivery",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksToDelivery_OrderId",
                table: "BooksToDelivery",
                newName: "IX_BooksToDelivery_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksToDelivery_Book_BookId",
                table: "BooksToDelivery",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
