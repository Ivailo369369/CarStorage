using CarStorage.Core.Application.Dtos.Cars;
using CarStorage.Core.Domain.CarStorage.Entities;

using AutoMapper;

namespace CarStorage.Infrastructure.Configurations.Mapper.Profiles.Cars
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
