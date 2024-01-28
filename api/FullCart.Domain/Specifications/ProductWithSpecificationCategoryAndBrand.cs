using FullCart.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FullCart.Domain;

public class ProductWithSpecificationCategoryAndBrand: BaseSpecification<Product>
{
     public ProductWithSpecificationCategoryAndBrand([FromQuery]ProductSpecParams productSpecPrams)
            : base
            (x =>
            (string.IsNullOrEmpty(productSpecPrams.Search) || x.ProductName == productSpecPrams.Search) &&
            (!productSpecPrams.brandId.HasValue || x.BrandId == productSpecPrams.brandId)
             && (!productSpecPrams.categoryId.HasValue || x.CategoryId == productSpecPrams.categoryId))
        {
          AddInclude(Y=>Y.Category);
          AddInclude(Y=>Y.Category);
          AddInclude(Z=>Z.Brand);
          AddOrderBy(x=>x.ProductName);
          ApplyPagging(productSpecPrams.pageSize*(productSpecPrams.pageIndex),productSpecPrams.pageSize);
            if(string.IsNullOrEmpty(productSpecPrams.sort))
            {
                switch(productSpecPrams.sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.ProductPrice);
                        break;
                    case "priceDesc":
                        AddOrderByDecending(p=> p.ProductPrice);
                        break;
                    default:
                        AddOrderBy(n => n.ProductName);
                        break;
                }
            }
        }

        public ProductWithSpecificationCategoryAndBrand(Guid Id) 
            : base(x=>x.Id==Id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }

}
