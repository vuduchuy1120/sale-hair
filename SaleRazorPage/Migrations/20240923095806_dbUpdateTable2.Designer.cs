﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SaleRazorPage.Model;

#nullable disable

namespace SaleRazorPage.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240923095806_dbUpdateTable2")]
    partial class dbUpdateTable2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SaleRazorPage.Model.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameUnAccent")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SaleRazorPage.Model.CategoryThickness", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ThicknessId")
                        .HasColumnType("uuid");

                    b.HasKey("CategoryId", "ThicknessId");

                    b.HasIndex("ThicknessId");

                    b.ToTable("CategoryThickness");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NameUnAccent")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Ward")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SaleRazorPage.Model.GridColor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NameUnAccent")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("GridColors");
                });

            modelBuilder.Entity("SaleRazorPage.Model.GridSize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameUnAccent")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("GridSizes");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Length", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameUnAccent")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Lengths");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly?>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("OrderDate")
                        .HasColumnType("date");

                    b.Property<double?>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SaleRazorPage.Model.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SetHairRequestId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("GridColorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ThorneId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LengthId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("GridSizeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ThicknessId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uuid");

                    b.Property<bool?>("IsBorder")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<double?>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("SubTypeHairCategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubTypeHairColorId")
                        .HasColumnType("uuid");

                    b.Property<string>("SubTypeHairSubTypeName")
                        .HasColumnType("text");

                    b.Property<Guid?>("SubTypeHairTypeHairId")
                        .HasColumnType("uuid");

                    b.Property<string>("SubTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TypeHairId")
                        .HasColumnType("uuid");

                    b.HasKey("OrderId", "SetHairRequestId", "GridColorId", "ThorneId", "LengthId", "GridSizeId", "ThicknessId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("GridColorId");

                    b.HasIndex("GridSizeId");

                    b.HasIndex("LengthId");

                    b.HasIndex("SetHairRequestId");

                    b.HasIndex("ThicknessId");

                    b.HasIndex("ThorneId");

                    b.HasIndex("TypeHairId");

                    b.HasIndex("SubTypeHairColorId", "SubTypeHairCategoryId", "SubTypeHairTypeHairId", "SubTypeHairSubTypeName");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SetHairRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Id");

                    b.ToTable("HairRequests");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SubTypeHair", b =>
                {
                    b.Property<Guid>("ColorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TypeHairId")
                        .HasColumnType("uuid");

                    b.Property<string>("SubTypeName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("SubTypeNameUnAccent")
                        .HasColumnType("text");

                    b.HasKey("ColorId", "CategoryId", "TypeHairId", "SubTypeName");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TypeHairId");

                    b.ToTable("SubTypeHairs");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Thickness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameUnAccent")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Thickness");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Thorne", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameUnAccent")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Thornes");
                });

            modelBuilder.Entity("SaleRazorPage.Model.TypeHair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameUnAccent")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("TypeHairs");
                });

            modelBuilder.Entity("SaleRazorPage.Model.CategoryThickness", b =>
                {
                    b.HasOne("SaleRazorPage.Model.Category", "Category")
                        .WithMany("CategoryThicknesses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.Thickness", "Thickness")
                        .WithMany("CategoryThicknesses")
                        .HasForeignKey("ThicknessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Thickness");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Order", b =>
                {
                    b.HasOne("SaleRazorPage.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SaleRazorPage.Model.OrderDetail", b =>
                {
                    b.HasOne("SaleRazorPage.Model.Category", "Category")
                        .WithMany("OrderDetails")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.Color", "Color")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.GridColor", "GridColor")
                        .WithMany("OrderDetails")
                        .HasForeignKey("GridColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.GridSize", "GridSize")
                        .WithMany("OrderDetails")
                        .HasForeignKey("GridSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.Length", "Length")
                        .WithMany("OrderDetails")
                        .HasForeignKey("LengthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.SetHairRequest", "SetHairRequest")
                        .WithMany("OrderDetails")
                        .HasForeignKey("SetHairRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.Thickness", "Thickness")
                        .WithMany()
                        .HasForeignKey("ThicknessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.Thorne", "Thorne")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ThorneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.TypeHair", "TypeHair")
                        .WithMany("OrderDetails")
                        .HasForeignKey("TypeHairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.SubTypeHair", "SubTypeHair")
                        .WithMany("OrderDetails")
                        .HasForeignKey("SubTypeHairColorId", "SubTypeHairCategoryId", "SubTypeHairTypeHairId", "SubTypeHairSubTypeName");

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("GridColor");

                    b.Navigation("GridSize");

                    b.Navigation("Length");

                    b.Navigation("Order");

                    b.Navigation("SetHairRequest");

                    b.Navigation("SubTypeHair");

                    b.Navigation("Thickness");

                    b.Navigation("Thorne");

                    b.Navigation("TypeHair");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SetHairRequest", b =>
                {
                    b.HasOne("SaleRazorPage.Model.Category", "Category")
                        .WithMany("SetHairsRequest")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SubTypeHair", b =>
                {
                    b.HasOne("SaleRazorPage.Model.Category", "Category")
                        .WithMany("SubTypeHairs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.Color", "Color")
                        .WithMany("SubTypeHairs")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.TypeHair", "TypeHair")
                        .WithMany("Subtypes")
                        .HasForeignKey("TypeHairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("TypeHair");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Category", b =>
                {
                    b.Navigation("CategoryThicknesses");

                    b.Navigation("OrderDetails");

                    b.Navigation("SetHairsRequest");

                    b.Navigation("SubTypeHairs");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Color", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("SubTypeHairs");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SaleRazorPage.Model.GridColor", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SaleRazorPage.Model.GridSize", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Length", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SetHairRequest", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SubTypeHair", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Thickness", b =>
                {
                    b.Navigation("CategoryThicknesses");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Thorne", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SaleRazorPage.Model.TypeHair", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Subtypes");
                });
#pragma warning restore 612, 618
        }
    }
}
