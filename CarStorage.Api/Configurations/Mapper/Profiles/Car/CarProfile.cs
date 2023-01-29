using CarStorage.Api.Models.Cars;
using CarStorage.Core.Application.Dtos.Cars;

using AutoMapper;

namespace CarStorage.Api.Configurations.Mapper.Profiles.Car
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarDto, ApiCarModel>();
        }
    }
}
