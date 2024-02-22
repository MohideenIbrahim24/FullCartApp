using System.ComponentModel.DataAnnotations;

namespace FullCart.Domain;

public class Category : BaseAuditableEntity

{
    [Required(ErrorMessage = "Category Name is required.")]
    [StringLength(80)]
    public string CategoryName { get; set; }    
    public string CategoryDescription { get; set; }
    public int CategoryDisplayOrder { get; set; }
    //public ICollection<Product> Products { get; } = new List<Product>();
    //public ICollection<CartItem> CartItems { get; } = new List<CartItem>();
    public Category()
    {
        this.Id = Guid.NewGuid();
    }


}
