using ECommerceApp.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;


namespace ECommerceApp.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public string CustomerID { get; set; }  // Foreign key referencing the Id in ApplicationUser

        public ApplicationUser Customer { get; set; }  // Navigation property

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(50)]
        public string OrderStatus { get; set; }  // Example: "Shipped", "Pending"

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(250)]
        public string ShippingAddress { get; set; }

        public int? PaymentID { get; set; }  // Nullable foreign key, as payment might be made later

        [InverseProperty("Order")]
        public Payment Payment { get; set; }  // Navigation property

        public ICollection<OrderDetails> OrderDetails { get; set; }  // Navigation property to OrderDetails
    }
}
