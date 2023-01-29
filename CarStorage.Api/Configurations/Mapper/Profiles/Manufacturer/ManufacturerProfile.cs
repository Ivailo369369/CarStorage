using CarStorage.Api.Models.Manufacturers;
using CarStorage.Core.Application.Dtos.Manufacturers;

using AutoMapper;

namespace CarStorage.Api.Configurations.Mapper.Profiles.Manufacturer
{
    public class ManufacturerProfile : Profile
    {
        public ManufacturerProfile()
        {
            CreateMap<ManufacturerDto, ApiManufacturerModel>();
        }
    }
}
