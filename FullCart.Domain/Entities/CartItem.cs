using FullCart.Domain.Common;
using System.ComponentModel;
using System.Reflection.Metadata;

namespace FullCart.Domain.Entities
{
    public class CartItem : BaseAuditableEntity
    {
        public string CartItemName { get; set; }
        public double CartItemPrice { get; set; }
        public int CartItemQuantity { get; set; }
        public string CartItemImageUrl { get; set; }
        
        [DisplayName("CartItemCategoryId")]
        public Guid CategoryId{ get; set; }
        public Category Category { get; set; } = null!;
        [DisplayName("CartItemBrandId")]
        public Guid  BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        

    }
}