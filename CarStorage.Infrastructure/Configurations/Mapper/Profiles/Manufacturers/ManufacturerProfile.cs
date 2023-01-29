using CarStorage.Core.Application.Dtos.Manufacturers;
using CarStorage.Core.Domain.CarStorage.Entities;

using AutoMapper;

namespace CarStorage.Infrastructure.Configurations.Mapper.Profiles.Manufacturers
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<Manufacturer, ManufacturerDto>();
        }
    }
}
