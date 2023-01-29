using CarStorage.Api.Models.Categories;
using CarStorage.Core.Application.Dtos.Categories;

using AutoMapper;

namespace CarStorage.Api.Configurations.Mapper.Profiles.Category
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, ApiCategoryModel>();
        }
    }
}
