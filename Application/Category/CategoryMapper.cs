using Application.Category.Add;
using Application.Category.List;
using Application.Category.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Category;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        //Create
        CreateMap<AddCategoryRequest, CategoryEntity>();
        
        //List
        CreateMap<CategoryEntity, ListCategoryResponse>();
        
        //Update
        CreateMap<UpdateCategoryRequest, CategoryEntity>();
    }
}