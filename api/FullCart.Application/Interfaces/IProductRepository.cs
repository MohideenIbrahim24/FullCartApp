using FullCart.Domain;
using FullCart.Domain.Entities;

namespace FullCart.Application;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(Guid Id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<IReadOnlyList<Category>> GetCategoryAsync();
    Task<IReadOnlyList<Brand>> GetBrandAsync();
}
