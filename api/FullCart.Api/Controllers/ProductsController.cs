using AutoMapper;
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
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        public IMapper _Mapper;

        public ProductsController(IGenericRepository<Product> productRepository,
            IGenericRepository<Brand> brandRepository, 
            IGenericRepository<Category> categoryRepository, 
            IMapper mapper)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductWithSpecificationCategoryAndBrand(productSpecParams);
            var speccount = new ProductWithFilterCountSpecification(productSpecParams);
            var total = await _productRepository.CountAsync(spec);
            var products = await _productRepository.ListAsync(spec);
            var data = _Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            return Ok(new Pagination<ProductDto>(productSpecParams.pageIndex, productSpecParams.pageSize, total, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // or any other appropriate action for a not-found product
            }
            return Ok(product);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Brand>>> GetBrands()
        {
            var brands = await _brandRepository.GetAllAsync();
            return Ok(brands);
        }
    }
}