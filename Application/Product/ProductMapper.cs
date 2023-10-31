using Application.Product.Add;
using Application.Product.List;
using Application.Product.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Product;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        
        //List
        CreateMap<ProductEntity, ListProductsResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        
        //Update
        CreateMap<UpdateProductRequest, ProductEntity>()
            .ForMember(dest => dest.Price, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

    }
}