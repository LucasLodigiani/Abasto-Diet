using Application.Product.Add;
using Application.Product.List;
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
    }
}