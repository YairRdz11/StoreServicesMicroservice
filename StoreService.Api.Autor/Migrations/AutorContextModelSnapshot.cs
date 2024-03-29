﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreService.Api.Autor.Persistent;

#nullable disable

namespace StoreService.Api.Autor.Migrations
{
    [DbContext(typeof(AutorContext))]
    partial class AutorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StoreService.Api.Autor.Models.AcademicGrade", b =>
                {
                    b.Property<int>("AcademicGradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AcademicGradeId"));

                    b.Property<string>("AcademicCenter")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AcademicGradeGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AutorBookId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("GradeDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AcademicGradeId");

                    b.HasIndex("AutorBookId");

                    b.ToTable("AcademicGrade");
                });

            modelBuilder.Entity("StoreService.Api.Autor.Models.AutorBook", b =>
                {
                    b.Property<int>("AutorBookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AutorBookId"));

                    b.Property<string>("AutorBookGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AutorBookId");

                    b.ToTable("AutorBook");
                });

            modelBuilder.Entity("StoreService.Api.Autor.Models.AcademicGrade", b =>
                {
                    b.HasOne("StoreService.Api.Autor.Models.AutorBook", "AutorBook")
                        .WithMany("AcademicGradeList")
                        .HasForeignKey("AutorBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutorBook");
                });

            modelBuilder.Entity("StoreService.Api.Autor.Models.AutorBook", b =>
                {
                    b.Navigation("AcademicGradeList");
                });
#pragma warning restore 612, 618
        }
    }
}
