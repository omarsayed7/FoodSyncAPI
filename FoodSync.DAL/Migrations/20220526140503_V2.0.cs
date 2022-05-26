using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodSync.DAL.Migrations
{
    public partial class V20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrandRawMaterial",
                columns: table => new
                {
                    BrandsId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialsid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandRawMaterial", x => new { x.BrandsId, x.RawMaterialsid });
                    table.ForeignKey(
                        name: "FK_BrandRawMaterial_Brands_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandRawMaterial_RawMaterials_RawMaterialsid",
                        column: x => x.RawMaterialsid,
                        principalTable: "RawMaterials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumption",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalRecord = table.Column<double>(type: "float", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumption_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyOperations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrsIn = table.Column<double>(type: "float", nullable: false),
                    TrsOut = table.Column<double>(type: "float", nullable: false),
                    Waste = table.Column<double>(type: "float", nullable: false),
                    FactoryRecivingQty = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    RawMaterialid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyOperations_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyOperations_RawMaterials_RawMaterialid",
                        column: x => x.RawMaterialid,
                        principalTable: "RawMaterials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpenningClosingQties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Months = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    RawMaterialid = table.Column<long>(type: "bigint", nullable: true),
                    OpenningQty = table.Column<double>(type: "float", nullable: false),
                    ClosingQty = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenningClosingQties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenningClosingQties_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OpenningClosingQties_RawMaterials_RawMaterialid",
                        column: x => x.RawMaterialid,
                        principalTable: "RawMaterials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRawMaterial",
                columns: table => new
                {
                    ProductsId = table.Column<long>(type: "bigint", nullable: false),
                    RawMaterialsid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRawMaterial", x => new { x.ProductsId, x.RawMaterialsid });
                    table.ForeignKey(
                        name: "FK_ProductRawMaterial_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRawMaterial_RawMaterials_RawMaterialsid",
                        column: x => x.RawMaterialsid,
                        principalTable: "RawMaterials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    SaleQty = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BrandId",
                table: "Branches",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandRawMaterial_RawMaterialsid",
                table: "BrandRawMaterial",
                column: "RawMaterialsid");

            migrationBuilder.CreateIndex(
                name: "IX_Consumption_BranchId",
                table: "Consumption",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyOperations_BranchId",
                table: "DailyOperations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyOperations_RawMaterialid",
                table: "DailyOperations",
                column: "RawMaterialid");

            migrationBuilder.CreateIndex(
                name: "IX_OpenningClosingQties_BranchId",
                table: "OpenningClosingQties",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenningClosingQties_RawMaterialid",
                table: "OpenningClosingQties",
                column: "RawMaterialid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRawMaterial_RawMaterialsid",
                table: "ProductRawMaterial",
                column: "RawMaterialsid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BranchId",
                table: "Sales",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandRawMaterial");

            migrationBuilder.DropTable(
                name: "Consumption");

            migrationBuilder.DropTable(
                name: "DailyOperations");

            migrationBuilder.DropTable(
                name: "OpenningClosingQties");

            migrationBuilder.DropTable(
                name: "ProductRawMaterial");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
