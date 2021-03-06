// <auto-generated />
using System;
using FoodSync.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodSync.DAL.Migrations
{
    [DbContext(typeof(FoodSyncDbContext))]
    [Migration("20220528152446_v2.3.4")]
    partial class v234
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BrandRawMaterial", b =>
                {
                    b.Property<int>("BrandsId")
                        .HasColumnType("int");

                    b.Property<long>("RawMaterialsid")
                        .HasColumnType("bigint");

                    b.HasKey("BrandsId", "RawMaterialsid");

                    b.HasIndex("RawMaterialsid");

                    b.ToTable("BrandRawMaterial");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("BranchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Consumption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BranchId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ConsumptionDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("FinalRecord")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Consumption");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.DailyOperation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BranchId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("FactoryRecivingQty")
                        .HasColumnType("float");

                    b.Property<long?>("RawMaterialid")
                        .HasColumnType("bigint");

                    b.Property<double>("TrsIn")
                        .HasColumnType("float");

                    b.Property<double>("TrsOut")
                        .HasColumnType("float");

                    b.Property<double>("Waste")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("RawMaterialid");

                    b.ToTable("DailyOperations");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.OpenningClosingQty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BranchId")
                        .HasColumnType("bigint");

                    b.Property<double>("ClosingQty")
                        .HasColumnType("float");

                    b.Property<int>("Months")
                        .HasColumnType("int");

                    b.Property<double>("OpenningQty")
                        .HasColumnType("float");

                    b.Property<long?>("RawMaterialid")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("RawMaterialid");

                    b.ToTable("OpenningClosingQties");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.ProductRawMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<long>("RawMaterialId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RawMaterialId");

                    b.ToTable("ProductRawMaterial");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.ProductSale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<long>("SaleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("ProductSales");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.RawMaterial", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("RawMaterials");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BranchId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("BranchId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BrandRawMaterial", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodSync.DAL.Entites.RawMaterial", null)
                        .WithMany()
                        .HasForeignKey("RawMaterialsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Branch", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Brand", null)
                        .WithMany("Branches")
                        .HasForeignKey("BrandId");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Consumption", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Branch", "Branch")
                        .WithMany("Consumptions")
                        .HasForeignKey("BranchId");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.DailyOperation", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Branch", "Branch")
                        .WithMany("DailyOperations")
                        .HasForeignKey("BranchId");

                    b.HasOne("FoodSync.DAL.Entites.RawMaterial", "RawMaterial")
                        .WithMany("DailyOperations")
                        .HasForeignKey("RawMaterialid");

                    b.Navigation("Branch");

                    b.Navigation("RawMaterial");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.OpenningClosingQty", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Branch", "Branch")
                        .WithMany("OpenningClosingQties")
                        .HasForeignKey("BranchId");

                    b.HasOne("FoodSync.DAL.Entites.RawMaterial", "RawMaterial")
                        .WithMany("OpenningClosingQties")
                        .HasForeignKey("RawMaterialid");

                    b.Navigation("Branch");

                    b.Navigation("RawMaterial");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Product", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.ProductRawMaterial", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Product", "Product")
                        .WithMany("ProductRawMaterials")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodSync.DAL.Entites.RawMaterial", "RawMaterial")
                        .WithMany("productRawMaterials")
                        .HasForeignKey("RawMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("RawMaterial");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.ProductSale", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Product", "Product")
                        .WithMany("ProductSales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodSync.DAL.Entites.Sale", "Sale")
                        .WithMany("ProductSales")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Sale", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Branch", "Branch")
                        .WithMany("Sales")
                        .HasForeignKey("BranchId");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.User", b =>
                {
                    b.HasOne("FoodSync.DAL.Entites.Branch", "Branch")
                        .WithOne("User")
                        .HasForeignKey("FoodSync.DAL.Entites.User", "BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Branch", b =>
                {
                    b.Navigation("Consumptions");

                    b.Navigation("DailyOperations");

                    b.Navigation("OpenningClosingQties");

                    b.Navigation("Sales");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Brand", b =>
                {
                    b.Navigation("Branches");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Product", b =>
                {
                    b.Navigation("ProductRawMaterials");

                    b.Navigation("ProductSales");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.RawMaterial", b =>
                {
                    b.Navigation("DailyOperations");

                    b.Navigation("OpenningClosingQties");

                    b.Navigation("productRawMaterials");
                });

            modelBuilder.Entity("FoodSync.DAL.Entites.Sale", b =>
                {
                    b.Navigation("ProductSales");
                });
#pragma warning restore 612, 618
        }
    }
}
