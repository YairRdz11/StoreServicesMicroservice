﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreService.Api.ShoppingCart.Persistant;

#nullable disable

namespace StoreService.Api.ShoppingCart.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    [Migration("20230914035425_MigrationMySQLInitial")]
    partial class MigrationMySQLInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StoreService.Api.ShoppingCart.Models.ShoppingCartSession", b =>
                {
                    b.Property<int>("ShoppingCartSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ShoppingCartSessionId");

                    b.ToTable("ShoppingCartSessions");
                });

            modelBuilder.Entity("StoreService.Api.ShoppingCart.Models.ShoppingCartSessionDetail", b =>
                {
                    b.Property<int>("ShoppingCartSessionDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SelectedProduct")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ShoppingCartSessionId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartSessionDetailId");

                    b.HasIndex("ShoppingCartSessionId");

                    b.ToTable("ShoppingCartSessionDetails");
                });

            modelBuilder.Entity("StoreService.Api.ShoppingCart.Models.ShoppingCartSessionDetail", b =>
                {
                    b.HasOne("StoreService.Api.ShoppingCart.Models.ShoppingCartSession", "ShoppingCartSession")
                        .WithMany("Details")
                        .HasForeignKey("ShoppingCartSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCartSession");
                });

            modelBuilder.Entity("StoreService.Api.ShoppingCart.Models.ShoppingCartSession", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
