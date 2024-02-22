using AutoMapper;
using FullCart.Api.DTOs;
using FullCart.Domain.Entities;
using FullCart.Domain.Entities.Identities;

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
            CreateMap<Address,AddressDto>().ReverseMap();
    }
}
