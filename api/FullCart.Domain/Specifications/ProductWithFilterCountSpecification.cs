using FullCart.Domain.Entities;

namespace FullCart.Domain;

public class ProductWithFilterCountSpecification: BaseSpecification<Product>
    {
        public ProductWithFilterCountSpecification(ProductSpecParams productSpecParams) :
            base      
            (x =>
            (string.IsNullOrEmpty(productSpecParams.search) || x.ProductName == productSpecParams.search) &&
            (!productSpecParams.brandId.HasValue || x.BrandId == productSpecParams.brandId)
             && (!productSpecParams.categoryId.HasValue || x.CategoryId == productSpecParams.categoryId))
        {

        }
    }
