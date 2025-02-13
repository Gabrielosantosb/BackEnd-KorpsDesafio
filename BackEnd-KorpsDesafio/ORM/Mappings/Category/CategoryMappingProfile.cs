using AutoMapper;
using BackEnd_KorpsDesafio.ORM.Entity.Category;
using BackEnd_KorpsDesafio.ORM.Model.Category;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryRequest, CategoryModel>();
    }
}
