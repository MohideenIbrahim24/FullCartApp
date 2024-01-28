using FullCart.Application;
using FullCart.Domain;
using FullCart.Domain.Entities;
using FullCart.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullCart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id){
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // or any other appropriate action for a not-found product
            }
            return Ok(product);            
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories(){
            var categories = await _productRepository.GetCategoryAsync();
            return Ok(categories);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Brand>>> GetBrands(){
            var brands = await _productRepository.GetBrandAsync();
            return Ok(brands);
        }
    }
}