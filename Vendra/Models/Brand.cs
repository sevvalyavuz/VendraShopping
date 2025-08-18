using System;

namespace Vendra.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
