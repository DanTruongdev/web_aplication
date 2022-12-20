using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Migrations
{
    public partial class CreatDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublicDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CusId);
                    table.ForeignKey(
                        name: "FK_Customers_Accounts_AccountEmail",
                        column: x => x.AccountEmail,
                        principalTable: "Accounts",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "BookBookCategory",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    CategoriesCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookCategory", x => new { x.BooksId, x.CategoriesCategoryID });
                    table.ForeignKey(
                        name: "FK_BookBookCategory_BookCategories_CategoriesCategoryID",
                        column: x => x.CategoriesCategoryID,
                        principalTable: "BookCategories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookCategory_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookCategory_CategoriesCategoryID",
                table: "BookBookCategory",
                column: "CategoriesCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountEmail",
                table: "Customers",
                column: "AccountEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookCategory");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
