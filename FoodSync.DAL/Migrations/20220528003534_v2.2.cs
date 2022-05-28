using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodSync.DAL.Migrations
{
    public partial class v22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterial_Products_ProductsId",
                table: "ProductRawMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterial_RawMaterials_RawMaterialsid",
                table: "ProductRawMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRawMaterial",
                table: "ProductRawMaterial");

            migrationBuilder.RenameColumn(
                name: "RawMaterialsid",
                table: "ProductRawMaterial",
                newName: "RawMaterialId");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ProductRawMaterial",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRawMaterial_RawMaterialsid",
                table: "ProductRawMaterial",
                newName: "IX_ProductRawMaterial_RawMaterialId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductRawMaterial",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "ProductRawMaterial",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRawMaterial",
                table: "ProductRawMaterial",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterial_ProductId",
                table: "ProductRawMaterial",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterial_Products_ProductId",
                table: "ProductRawMaterial",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterial_RawMaterials_RawMaterialId",
                table: "ProductRawMaterial",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterial_Products_ProductId",
                table: "ProductRawMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRawMaterial_RawMaterials_RawMaterialId",
                table: "ProductRawMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRawMaterial",
                table: "ProductRawMaterial");

            migrationBuilder.DropIndex(
                name: "IX_ProductRawMaterial_ProductId",
                table: "ProductRawMaterial");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductRawMaterial");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductRawMaterial");

            migrationBuilder.RenameColumn(
                name: "RawMaterialId",
                table: "ProductRawMaterial",
                newName: "RawMaterialsid");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductRawMaterial",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRawMaterial_RawMaterialId",
                table: "ProductRawMaterial",
                newName: "IX_ProductRawMaterial_RawMaterialsid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRawMaterial",
                table: "ProductRawMaterial",
                columns: new[] { "ProductsId", "RawMaterialsid" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterial_Products_ProductsId",
                table: "ProductRawMaterial",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRawMaterial_RawMaterials_RawMaterialsid",
                table: "ProductRawMaterial",
                column: "RawMaterialsid",
                principalTable: "RawMaterials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
