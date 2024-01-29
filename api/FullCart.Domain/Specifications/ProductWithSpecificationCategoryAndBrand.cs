using FullCart.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.Domain;

public class ProductWithSpecificationCategoryAndBrand : BaseSpecification<Product>
{
    public ProductWithSpecificationCategoryAndBrand([FromQuery] ProductSpecParams productSpecParams)
           : base
           (x =>
           (string.IsNullOrEmpty(productSpecParams.search) || x.ProductName == productSpecParams.search) &&
           (!productSpecParams.brandId.HasValue || x.BrandId == productSpecParams.brandId)
            && (!productSpecParams.categoryId.HasValue || x.CategoryId == productSpecParams.categoryId))
    {
        AddInclude(Y => Y.Category);
        AddInclude(Z => Z.Brand);
        AddOrderBy(x => x.ProductName);

        ApplyPaging(productSpecParams.pageSize * (productSpecParams.pageIndex - 1), productSpecParams.pageSize);
        if (!string.IsNullOrEmpty(productSpecParams.sort))
        {
            switch (productSpecParams.sort)
            {
                case "productPriceAsc":
                    AddOrderBy(p => p.ProductPrice);
                    break;
                case "productPriceDesc":
                    AddOrderByDecending(p => p.ProductPrice);
                    break;
                default:
                    AddOrderBy(n => n.ProductName);
                    break;
            }
        }
    }

    public ProductWithSpecificationCategoryAndBrand(Guid Id)
        : base(x => x.Id == Id)
    {
        AddInclude(x => x.Category);
        AddInclude(x => x.Brand);
    }

}
