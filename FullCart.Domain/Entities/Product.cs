using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FullCart.Domain.Common;

namespace FullCart.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        
        public string ProductImageUrl { get; set; }
        [DisplayName("ProductCategoryId")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        [DisplayName("ProductBrandId")]
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; } = null!;



    }
}