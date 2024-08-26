// User.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class User
    {
        [Key] // This annotation specifies that Id is the primary key.
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")] // The Name field is required.
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters.")] // Limiting the length of Name to 100 characters.
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")] // The Email field is required.
        [EmailAddress(ErrorMessage = "Invalid Email Address")] // Ensures the format of Email is valid.
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")] // The Phone field is required.
        [Phone(ErrorMessage = "Invalid Phone Number")] // Ensures the format of Phone is valid.
        public string Phone { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")] // The Age should be between 1 and 120.
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")] // The Gender field is required.
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required")] // The Address field is required.
        [StringLength(200, ErrorMessage = "Address length can't be more than 200 characters.")] // Limiting the length of Address to 200 characters.
        public string Address { get; set; }

        [Required] // The UserType field is required.
        [Range(0, 1, ErrorMessage = "UserType must be either 0 (User) or 1 (Admin)")]
        public int UserType { get; set; } = 0; // Default value is 0 (User)
    }
}
