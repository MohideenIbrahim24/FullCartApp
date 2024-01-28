using FullCart.Domain.Entities;

namespace FullCart.Domain;

public class ProductWithFilterCountSpecification: BaseSpecification<Product>
    {
        public ProductWithFilterCountSpecification(ProductSpecParams productSpecParams) :
            base      
            (x =>
            (string.IsNullOrEmpty(productSpecParams.Search) || x.ProductName == productSpecParams.Search) &&
            (!productSpecParams.brandId.HasValue || x.BrandId == productSpecParams.brandId)
             && (!productSpecParams.categoryId.HasValue || x.CategoryId == productSpecParams.categoryId))
        {

        }
    }
