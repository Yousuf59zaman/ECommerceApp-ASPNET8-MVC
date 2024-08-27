using System;

namespace ECommerceApp.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }  // Primary Key
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int ProductUnitPrice { get; set; }
        public string? ProductImage { get; set; }  // Nullable

        // Foreign Key
        public Guid CategoryId { get; set; }  // Foreign Key to Category
        public Category Category { get; set; }  // Navigation property
    }
}
