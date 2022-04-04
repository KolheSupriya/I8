﻿// <auto-generated />
using System;
using InventoryManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryManagementSystem.Migrations
{
    [DbContext(typeof(MyDebContext))]
    [Migration("20220404072815_I3")]
    partial class I3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("InventoryManagementSystem.PRODUCTS", b =>
                {
                    b.Property<int>("Products_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Current_Storage")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Product_Category_ID")
                        .HasColumnType("int");

                    b.Property<int>("Remaining_Quantity")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<int>("Sold")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<string>("SubProduct_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Total_Selling_Amount")
                        .HasMaxLength(30)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Unit_Price")
                        .HasMaxLength(30)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Products_ID");

                    b.HasIndex("Product_Category_ID");

                    b.ToTable("PRODUCTS");
                });

            modelBuilder.Entity("InventoryManagementSystem.PRODUCT_CATEGORIES", b =>
                {
                    b.Property<int>("Product_Category_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Product_Category_ID");

                    b.ToTable("PRODUCT_CATEGORIES");
                });

            modelBuilder.Entity("InventoryManagementSystem.ROLE", b =>
                {
                    b.Property<int>("Role_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Role_ID");

                    b.ToTable("ROLES");
                });

            modelBuilder.Entity("InventoryManagementSystem.USERS", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Product_Access")
                        .HasColumnType("int");

                    b.Property<int>("Role_ID")
                        .HasColumnType("int");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Zip_Code")
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    b.HasKey("User_ID");

                    b.HasIndex("Product_Access");

                    b.HasIndex("Role_ID");

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("InventoryManagementSystem.PRODUCTS", b =>
                {
                    b.HasOne("InventoryManagementSystem.PRODUCT_CATEGORIES", "ProductCategories")
                        .WithMany("Products")
                        .HasForeignKey("Product_Category_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("InventoryManagementSystem.USERS", b =>
                {
                    b.HasOne("InventoryManagementSystem.PRODUCT_CATEGORIES", "ProductsList")
                        .WithMany("users")
                        .HasForeignKey("Product_Access")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventoryManagementSystem.ROLE", "ROLE")
                        .WithMany("USERS")
                        .HasForeignKey("Role_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductsList");

                    b.Navigation("ROLE");
                });

            modelBuilder.Entity("InventoryManagementSystem.PRODUCT_CATEGORIES", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("users");
                });

            modelBuilder.Entity("InventoryManagementSystem.ROLE", b =>
                {
                    b.Navigation("USERS");
                });
#pragma warning restore 612, 618
        }
    }
}
