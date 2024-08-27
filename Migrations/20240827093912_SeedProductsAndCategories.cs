using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("cd861779-8155-46e0-8095-e3000a21b822"), "Refrigerators", "Home Appliances" },
                    { new Guid("f92aa932-232d-49b7-848f-8ed95b86467c"), "Mobile Phones", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDesc", "ProductImage", "ProductName", "ProductUnitPrice" },
                values: new object[,]
                {
                    { new Guid("0f805d89-e022-4c3c-a66b-e075d10d973f"), new Guid("f92aa932-232d-49b7-848f-8ed95b86467c"), "Latest Apple iPhone 13 with A15 Bionic chip.", "iphone13.jpg", "iPhone 13", 999 },
                    { new Guid("d356356b-7c79-485b-9400-ea5ff942c018"), new Guid("f92aa932-232d-49b7-848f-8ed95b86467c"), "Samsung Galaxy S21 with Exynos 2100.", "galaxys21.jpg", "Samsung Galaxy S21", 799 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("cd861779-8155-46e0-8095-e3000a21b822"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("0f805d89-e022-4c3c-a66b-e075d10d973f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d356356b-7c79-485b-9400-ea5ff942c018"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("f92aa932-232d-49b7-848f-8ed95b86467c"));
        }
    }
}
