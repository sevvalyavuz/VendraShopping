using System.ComponentModel.DataAnnotations;

namespace Vendra.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur")]
        [Range(0.01, 1000000, ErrorMessage = "Geçerli bir fiyat giriniz")]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Stok adedi zorunludur")]
        [Range(0, 100000, ErrorMessage = "Geçerli bir stok adedi giriniz")]
        public int Stock { get; set; }

        [Display(Name = "Kategori")]
        public string? Category { get; set; }

        [Display(Name = "Ürün Görseli")]
        public string ImageUrl { get; set; }
        public string SellerId { get; set; }
        public string Color { get; set; }
        public int BrandId { get; set; }
    }
}
