using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentStatusToPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("03af819f-6b91-4ab2-a3a8-18bc3b569a6d"), "Mobile Phones", "Electronics" },
                    { new Guid("f89cb0d7-a2d6-406b-97da-ffacfe7a4dcf"), "Refrigerators", "Home Appliances" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDesc", "ProductImage", "ProductName", "ProductUnitPrice" },
                values: new object[,]
                {
                    { new Guid("1876e718-3e9e-43fd-b2a4-783f972a6b59"), new Guid("03af819f-6b91-4ab2-a3a8-18bc3b569a6d"), "Samsung Galaxy S21 with Exynos 2100.", "galaxys21.jpg", "Samsung Galaxy S21", 799 },
                    { new Guid("c1f25650-4973-4c76-91f9-cd6b3417e0cc"), new Guid("03af819f-6b91-4ab2-a3a8-18bc3b569a6d"), "Latest Apple iPhone 13 with A15 Bionic chip.", "iphone13.jpg", "iPhone 13", 999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("f89cb0d7-a2d6-406b-97da-ffacfe7a4dcf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1876e718-3e9e-43fd-b2a4-783f972a6b59"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c1f25650-4973-4c76-91f9-cd6b3417e0cc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("03af819f-6b91-4ab2-a3a8-18bc3b569a6d"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Payments");

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
    }
}
