using AutoMapper;
using FullCart.Domain.Entities;

namespace FullCart.Api;

public class ProductImageUrlResolver: IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _iconfiguration;

        public ProductImageUrlResolver(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ProductImageUrl))
            {
               return _iconfiguration["ApiKey"] + source.ProductImageUrl;
            }
            else
            {
                return null!;
            }
        }
    }
