using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int ProductID { get; set; }  // Foreign key to Product

        public Product Product { get; set; }  // Navigation property

        [Required]
        public int Quantity { get; set; }  // Quantity of products

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }  // Price per unit

        [NotMapped]
        public decimal Total => Quantity * UnitPrice;  // Total = Quantity * UnitPrice
    }
}
