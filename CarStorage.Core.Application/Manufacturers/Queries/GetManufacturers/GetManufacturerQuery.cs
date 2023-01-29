using CarStorage.Core.Application.Dtos.Manufacturers;

using MediatR;

namespace CarStorage.Core.Application.Manufacturers.Queries.GetManufacturers
{
    public class GetManufacturerQuery : IRequest<List<ManufacturerDto>>
    {
    }
}
