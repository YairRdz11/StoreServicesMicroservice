using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StoreService.Api.Autor.Migrations
{
    public partial class InitialPostgresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorBook",
                columns: table => new
                {
                    AutorBookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorBookGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorBook", x => x.AutorBookId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicGrade",
                columns: table => new
                {
                    AcademicGradeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AcademicCenter = table.Column<string>(type: "text", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorBookId = table.Column<int>(type: "integer", nullable: false),
                    AcademicGradeGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGrade", x => x.AcademicGradeId);
                    table.ForeignKey(
                        name: "FK_AcademicGrade_AutorBook_AutorBookId",
                        column: x => x.AutorBookId,
                        principalTable: "AutorBook",
                        principalColumn: "AutorBookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGrade_AutorBookId",
                table: "AcademicGrade",
                column: "AutorBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGrade");

            migrationBuilder.DropTable(
                name: "AutorBook");
        }
    }
}
