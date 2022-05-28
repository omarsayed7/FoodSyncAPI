using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodSync.DAL.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Products_ProductsId",
                table: "ProductSale");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Sales_SalesId",
                table: "ProductSale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSale",
                table: "ProductSale");

            migrationBuilder.DropColumn(
                name: "SaleQty",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "SalesId",
                table: "ProductSale",
                newName: "SaleId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductSale",
                newName: "Quantity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSale_SalesId",
                table: "ProductSale",
                newName: "IX_ProductSale_SaleId");

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProductSale",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ProductSale",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSale",
                table: "ProductSale",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_ProductId",
                table: "ProductSale",
                column: "ProductId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_ProductSale_ProductId",
                table: "ProductSale");

            migrationBuilder.DropColumn(
                name: "SaleDate",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductSale");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductSale");

            migrationBuilder.RenameColumn(
                name: "SaleId",
                table: "ProductSale",
                newName: "SalesId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductSale",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSale_SaleId",
                table: "ProductSale",
                newName: "IX_ProductSale_SalesId");

            migrationBuilder.AddColumn<long>(
                name: "SaleQty",
                table: "Sales",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSale",
                table: "ProductSale",
                columns: new[] { "ProductsId", "SalesId" });

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
    }
}
