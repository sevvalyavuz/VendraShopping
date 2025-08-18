using System.ComponentModel.DataAnnotations.Schema;

namespace Vendra.Models
{
    public class AdminUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
