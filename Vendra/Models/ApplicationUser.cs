using Microsoft.AspNetCore.Identity;

namespace Vendra.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Type { get; set; }  // Customer veya Seller
    }

    public enum UserType
    {
        Customer,
        Seller,
        Admin,
        User
    }
}

