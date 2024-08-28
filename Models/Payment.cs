using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }  // Foreign key to Order

        public Order Order { get; set; }  // Navigation property

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaymentAmount { get; set; }

        [Required]
        [MaxLength(50)]
        public string Method { get; set; }  // Payment method, e.g., "COD", "Credit Card"
    }
}
