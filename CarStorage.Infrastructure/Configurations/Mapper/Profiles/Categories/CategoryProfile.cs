using CarStorage.Core.Application.Dtos.Categories;
using CarStorage.Core.Domain.CarStorage.Entities;

using AutoMapper;

namespace CarStorage.Infrastructure.Configurations.Mapper.Profiles.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
