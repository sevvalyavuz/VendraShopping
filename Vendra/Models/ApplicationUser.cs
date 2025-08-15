using Microsoft.AspNetCore.Identity;

namespace Vendra.Models
{
    public class ApplicationUser : IdentityUser
    {
        public UserType Type { get; set; }  // Customer veya Seller
    }

    public enum UserType
    {
        Customer,
        Seller
    }
}

