﻿// <auto-generated />
using System;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210312085918_addedDescription")]
    partial class addedDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("FileExtention")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("ext");

                    b.Property<string>("FileName")
                        .HasMaxLength(260)
                        .HasColumnType("nvarchar(260)")
                        .HasColumnName("fileName");

                    b.Property<string>("MimeType")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("mime");

                    b.Property<string>("OriginalFileName")
                        .HasMaxLength(260)
                        .HasColumnType("nvarchar(260)")
                        .HasColumnName("original");

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a7f814d-7cb9-4390-a256-f63ee4c454c8"),
                            Name = "Пиво разливное"
                        },
                        new
                        {
                            Id = new Guid("b8732f78-8801-4589-b12e-c6e0605719c5"),
                            Name = "Пиво бутылочное"
                        },
                        new
                        {
                            Id = new Guid("86cdb0d6-b5a6-4b94-95bc-d940532e5a92"),
                            Name = "Снеки"
                        });
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("categoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("goods");
                });

            modelBuilder.Entity("Entities.ProductAsset", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("product_id");

                    b.Property<Guid>("AssetId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("asset_id");

                    b.HasKey("ProductId", "AssetId");

                    b.HasIndex("AssetId");

                    b.ToTable("goods_assets");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.ProductAsset", b =>
                {
                    b.HasOne("Entities.Asset", "Asset")
                        .WithMany("ProductAssets")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Product", "Product")
                        .WithMany("ProductAssets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asset");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Asset", b =>
                {
                    b.Navigation("ProductAssets");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Navigation("ProductAssets");
                });
#pragma warning restore 612, 618
        }
    }
}
