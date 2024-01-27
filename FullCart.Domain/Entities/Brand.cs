using FullCart.Domain.Common;

namespace FullCart.Domain.Entities
{
    public class Brand : BaseAuditableEntity
    {
        public string Name { get; set; }       
        public ICollection<Product> Products { get; } = new List<Product>();
        public ICollection<CartItem> CartItems { get; } = new List<CartItem>();
    }
}