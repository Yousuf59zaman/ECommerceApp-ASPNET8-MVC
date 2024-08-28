using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailsToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("8dc28ec5-35eb-4c90-8e27-d6a347297822"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d2094b7e-1ca2-406c-adbe-054d2a416560"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f6e04aae-df99-422e-bbf0-3a13be477e77"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("52c1a3b9-bb01-489b-83df-2bd5bdb478f5"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("2c7c0f96-7029-468b-9d63-065bb7f8795a"), "Refrigerators", "Home Appliances" },
                    { new Guid("5217df75-b514-4e54-b3d8-0c702ef49330"), "Mobile Phones", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDesc", "ProductImage", "ProductName", "ProductUnitPrice" },
                values: new object[,]
                {
                    { new Guid("a54464bb-81c7-4e08-831d-c4f353243236"), new Guid("5217df75-b514-4e54-b3d8-0c702ef49330"), "Latest Apple iPhone 13 with A15 Bionic chip.", "iphone13.jpg", "iPhone 13", 999 },
                    { new Guid("f30c926d-891c-4eba-bbc6-76e37a34c653"), new Guid("5217df75-b514-4e54-b3d8-0c702ef49330"), "Samsung Galaxy S21 with Exynos 2100.", "galaxys21.jpg", "Samsung Galaxy S21", 799 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("2c7c0f96-7029-468b-9d63-065bb7f8795a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a54464bb-81c7-4e08-831d-c4f353243236"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f30c926d-891c-4eba-bbc6-76e37a34c653"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("5217df75-b514-4e54-b3d8-0c702ef49330"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("52c1a3b9-bb01-489b-83df-2bd5bdb478f5"), "Mobile Phones", "Electronics" },
                    { new Guid("8dc28ec5-35eb-4c90-8e27-d6a347297822"), "Refrigerators", "Home Appliances" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDesc", "ProductImage", "ProductName", "ProductUnitPrice" },
                values: new object[,]
                {
                    { new Guid("d2094b7e-1ca2-406c-adbe-054d2a416560"), new Guid("52c1a3b9-bb01-489b-83df-2bd5bdb478f5"), "Samsung Galaxy S21 with Exynos 2100.", "galaxys21.jpg", "Samsung Galaxy S21", 799 },
                    { new Guid("f6e04aae-df99-422e-bbf0-3a13be477e77"), new Guid("52c1a3b9-bb01-489b-83df-2bd5bdb478f5"), "Latest Apple iPhone 13 with A15 Bionic chip.", "iphone13.jpg", "iPhone 13", 999 }
                });
        }
    }
}
