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
    [Migration("20240918094228_Update_Table_Sub_color")]
    partial class Update_Table_Sub_color
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

                    b.Property<Guid>("SubTypeHairId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("SaleRazorPage.Model.ColorRequest", b =>
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

                    b.Property<Guid>("SetHairRequestId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("SetHairRequestId");

                    b.ToTable("ColorRequests");
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

            modelBuilder.Entity("SaleRazorPage.Model.SubTypeColor", b =>
                {
                    b.Property<Guid>("SubTypeHairId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uuid");

                    b.HasKey("SubTypeHairId", "ColorId");

                    b.HasIndex("ColorId");

                    b.ToTable("SubTypeColors");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SubTypeHair", b =>
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

                    b.Property<Guid>("TypeHairId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("TypeHairId");

                    b.ToTable("SubTypeHairs");
                });

            modelBuilder.Entity("SaleRazorPage.Model.TypeHair", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
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

                    b.HasIndex("CategoryId");

                    b.HasIndex("Id");

                    b.ToTable("TypeHairs");
                });

            modelBuilder.Entity("SaleRazorPage.Model.ColorRequest", b =>
                {
                    b.HasOne("SaleRazorPage.Model.SetHairRequest", "SetHairRequest")
                        .WithMany("ColorRequests")
                        .HasForeignKey("SetHairRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SetHairRequest");
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

            modelBuilder.Entity("SaleRazorPage.Model.SubTypeColor", b =>
                {
                    b.HasOne("SaleRazorPage.Model.Color", "Color")
                        .WithMany("SubTypeColors")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaleRazorPage.Model.SubTypeHair", "SubTypeHair")
                        .WithMany("SubTypeColors")
                        .HasForeignKey("SubTypeHairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("SubTypeHair");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SubTypeHair", b =>
                {
                    b.HasOne("SaleRazorPage.Model.TypeHair", "TypeHair")
                        .WithMany("Subtypes")
                        .HasForeignKey("TypeHairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeHair");
                });

            modelBuilder.Entity("SaleRazorPage.Model.TypeHair", b =>
                {
                    b.HasOne("SaleRazorPage.Model.Category", "Category")
                        .WithMany("TypeHairs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Category", b =>
                {
                    b.Navigation("SetHairsRequest");

                    b.Navigation("TypeHairs");
                });

            modelBuilder.Entity("SaleRazorPage.Model.Color", b =>
                {
                    b.Navigation("SubTypeColors");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SetHairRequest", b =>
                {
                    b.Navigation("ColorRequests");
                });

            modelBuilder.Entity("SaleRazorPage.Model.SubTypeHair", b =>
                {
                    b.Navigation("SubTypeColors");
                });

            modelBuilder.Entity("SaleRazorPage.Model.TypeHair", b =>
                {
                    b.Navigation("Subtypes");
                });
#pragma warning restore 612, 618
        }
    }
}
