using System.ComponentModel.DataAnnotations;

namespace Vendra.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string SellerId { get; set; } // Ürünü ekleyen satıcı
    }
}

