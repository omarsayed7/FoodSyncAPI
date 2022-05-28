using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodSync.DAL.Migrations
{
    public partial class v231 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Products_ProductId",
                table: "ProductSale");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Sales_SaleId",
                table: "ProductSale");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "ProductSale",
                newName: "SalesId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductSale",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSale_SaleId",
                table: "ProductSale",
                newName: "IX_ProductSale_SalesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSale_ProductId",
                table: "ProductSale",
                newName: "IX_ProductSale_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSale_Products_ProductsId",
                table: "ProductSale",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSale_Sales_SalesId",
                table: "ProductSale",
                column: "SalesId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Products_ProductsId",
                table: "ProductSale");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Sales_SalesId",
                table: "ProductSale");

            migrationBuilder.RenameColumn(
                name: "SalesId",
                table: "ProductSale",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductSale",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSale_SalesId",
                table: "ProductSale",
                newName: "IX_ProductSale_SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSale_ProductsId",
                table: "ProductSale",
                newName: "IX_ProductSale_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSale_Products_ProductId",
                table: "ProductSale",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSale_Sales_SaleId",
                table: "ProductSale",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
