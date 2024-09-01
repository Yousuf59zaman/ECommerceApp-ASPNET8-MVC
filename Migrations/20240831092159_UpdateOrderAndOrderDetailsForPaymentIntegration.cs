using System;
using Microsoft.EntityFrameworkCore.Migrations;


namespace ECommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderAndOrderDetailsForPaymentIntegration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "CategoryType" },
                values: new object[,]
                {
                    { new Guid("2492c265-160a-4b2e-ab89-3b8013af5e50"), "Mobile Phones", "Electronics" },
                    { new Guid("f2a47e7b-ddf6-42d7-b59e-4a93da14765f"), "Refrigerators", "Home Appliances" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDesc", "ProductImage", "ProductName", "ProductUnitPrice" },
                values: new object[,]
                {
                    { new Guid("26809a2d-ca96-45be-806c-ef995f887c18"), new Guid("2492c265-160a-4b2e-ab89-3b8013af5e50"), "Samsung Galaxy S21 with Exynos 2100.", "galaxys21.jpg", "Samsung Galaxy S21", 799 },
                    { new Guid("7eddda7f-500f-4bf4-a528-d30f019613eb"), new Guid("2492c265-160a-4b2e-ab89-3b8013af5e50"), "Latest Apple iPhone 13 with A15 Bionic chip.", "iphone13.jpg", "iPhone 13", 999 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("f2a47e7b-ddf6-42d7-b59e-4a93da14765f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("26809a2d-ca96-45be-806c-ef995f887c18"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7eddda7f-500f-4bf4-a528-d30f019613eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("2492c265-160a-4b2e-ab89-3b8013af5e50"));

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
    }
}
