using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodSync.DAL.Migrations
{
    public partial class v234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Products_ProductId",
                table: "ProductSale");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Sales_SaleId",
                table: "ProductSale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSale",
                table: "ProductSale");

            migrationBuilder.RenameTable(
                name: "ProductSale",
                newName: "ProductSales");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSale_SaleId",
                table: "ProductSales",
                newName: "IX_ProductSales_SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSale_ProductId",
                table: "ProductSales",
                newName: "IX_ProductSales_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSales",
                table: "ProductSales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSales_Products_ProductId",
                table: "ProductSales",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSales_Sales_SaleId",
                table: "ProductSales",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSales_Products_ProductId",
                table: "ProductSales");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSales_Sales_SaleId",
                table: "ProductSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSales",
                table: "ProductSales");

            migrationBuilder.RenameTable(
                name: "ProductSales",
                newName: "ProductSale");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSales_SaleId",
                table: "ProductSale",
                newName: "IX_ProductSale_SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSales_ProductId",
                table: "ProductSale",
                newName: "IX_ProductSale_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSale",
                table: "ProductSale",
                column: "Id");

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
