using FullCart.Application;
using FullCart.Domain;
using FullCart.Domain.Entities;
using FullCart.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FullCart.Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly CartDbContext _cartDbContext;

    public ProductRepository(CartDbContext cartDbContext)
    {
        _cartDbContext = cartDbContext;
    }
    public async Task<Product> GetProductByIdAsync(Guid Id)
    {
        var product = await _cartDbContext.Products
        .Include(b => b.Brand)
        .Include(c => c.Category)
        .FirstOrDefaultAsync( p => p.Id == Id);
        
        if(product == null){
            return new Product();
        }
        return product;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _cartDbContext.Products
        .Include(b => b.Brand)
        .Include(c => c.Category)
        .ToListAsync();
    }

     public async Task<IReadOnlyList<Brand>> GetBrandAsync()
     {
        return await _cartDbContext.Brands.ToListAsync();
     }

    public async Task<IReadOnlyList<Category>> GetCategoryAsync()
    {
        return await _cartDbContext.Categories.ToListAsync();
    }
}
