using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System;


namespace ECommerceApp.Models
{
    public enum PaymentStatus
    {
        Pending,
        Successful
    }

    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int OrderID { get; set; } // Foreign key to Order

        [ForeignKey("OrderID")]
        [InverseProperty("Payment")]
        public Order Order { get; set; } // Navigation property

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PaymentAmount { get; set; }

        [Required]
        [MaxLength(50)]
        public string Method { get; set; } // Payment method, e.g., "COD", "Credit Card"

        [Required]
        public PaymentStatus Status { get; set; } // Payment status
    }
}

