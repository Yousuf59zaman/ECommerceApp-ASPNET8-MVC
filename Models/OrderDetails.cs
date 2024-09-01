using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ECommerceApp.Models
{
    public class OrderDetails
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }  // Foreign key to Order
        public Order Order { get; set; }  // Navigation property

        [Required]
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }  // Foreign key to Product
        public Product Product { get; set; }  // Navigation property

        [Required]
        public int Quantity { get; set; }  // Quantity of the product

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }  // Unit price of the product

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }  // Total price for this order detail (Quantity * UnitPrice)
    }
}
