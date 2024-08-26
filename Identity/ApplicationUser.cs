using Microsoft.AspNetCore.Identity;
namespace ECommerceApp.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
