using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreService.Api.ShoppingCart.Migrations
{
    public partial class MigrationMySQLInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoppingCartSessions",
                columns: table => new
                {
                    ShoppingCartSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSessions", x => x.ShoppingCartSessionId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShoppingCartSessionDetails",
                columns: table => new
                {
                    ShoppingCartSessionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SelectedProduct = table.Column<string>(type: "longtext", nullable: false),
                    ShoppingCartSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartSessionDetails", x => x.ShoppingCartSessionDetailId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartSessionDetails_ShoppingCartSessions_ShoppingCart~",
                        column: x => x.ShoppingCartSessionId,
                        principalTable: "ShoppingCartSessions",
                        principalColumn: "ShoppingCartSessionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartSessionDetails_ShoppingCartSessionId",
                table: "ShoppingCartSessionDetails",
                column: "ShoppingCartSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartSessionDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartSessions");
        }
    }
}
