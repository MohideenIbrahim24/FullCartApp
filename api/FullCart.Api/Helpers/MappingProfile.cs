using AutoMapper;
using FullCart.Domain.Entities;

namespace FullCart.Api;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Product,ProductDto>().
               ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
              .ForMember(p => p.Category, pt => pt.MapFrom(p => p.Category.CategoryName))
              .ForMember(p => p.ProductImageUrl,pt => pt.MapFrom<ProductImageUrlResolver>());
            // CreateMap<Core.Entities.Identity.Address, AddressDto>();
            // CreateMap<CustomerCart, CustomercartDto>();
            // CreateMap<CartItem,CartItemDto>();
            // CreateMap<AddressDto, Core.Entities.OrderAggregate.Address>();
    }
}
