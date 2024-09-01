using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderAndPaymentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentID",
                table: "Orders");

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
                    { new Guid("48645d15-498d-45e8-88e3-f896f0040863"), "Refrigerators", "Home Appliances" },
                    { new Guid("bb2bc0ae-60b0-4646-b524-b8713979a051"), "Mobile Phones", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDesc", "ProductImage", "ProductName", "ProductUnitPrice" },
                values: new object[,]
                {
                    { new Guid("195fe324-b565-4611-a4a0-0dd3db492e1d"), new Guid("bb2bc0ae-60b0-4646-b524-b8713979a051"), "Samsung Galaxy S21 with Exynos 2100.", "galaxys21.jpg", "Samsung Galaxy S21", 799 },
                    { new Guid("2341cd02-cc60-400e-ad74-422810e051b7"), new Guid("bb2bc0ae-60b0-4646-b524-b8713979a051"), "Latest Apple iPhone 13 with A15 Bionic chip.", "iphone13.jpg", "iPhone 13", 999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderID",
                table: "Payments",
                column: "OrderID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderID",
                table: "Payments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("48645d15-498d-45e8-88e3-f896f0040863"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("195fe324-b565-4611-a4a0-0dd3db492e1d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2341cd02-cc60-400e-ad74-422810e051b7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("bb2bc0ae-60b0-4646-b524-b8713979a051"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderID",
                table: "Payments",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentID",
                table: "Orders",
                column: "PaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentID",
                table: "Orders",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "PaymentID");
        }
    }
}
