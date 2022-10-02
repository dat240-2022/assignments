using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UiS.Dat240.Lab3.Migrations;

public partial class Initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "FoodItems",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: false),
                Price = table.Column<decimal>(type: "TEXT", nullable: false),
                CookTime = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FoodItems", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ShoppingCart",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ShoppingCart", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "CartItem",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                Sku = table.Column<int>(type: "INTEGER", nullable: false),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Price = table.Column<decimal>(type: "TEXT", nullable: false),
                Count = table.Column<int>(type: "INTEGER", nullable: false),
                ShoppingCartId = table.Column<Guid>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CartItem", x => x.Id);
                table.ForeignKey(
                    name: "FK_CartItem_ShoppingCart_ShoppingCartId",
                    column: x => x.ShoppingCartId,
                    principalTable: "ShoppingCart",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CartItem_ShoppingCartId",
            table: "CartItem",
            column: "ShoppingCartId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CartItem");

        migrationBuilder.DropTable(
            name: "FoodItems");

        migrationBuilder.DropTable(
            name: "ShoppingCart");
    }
}
