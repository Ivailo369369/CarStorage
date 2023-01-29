using CarStorage.Core.Application.Dtos.Manufacturers;

namespace CarStorage.Core.Application.Manufacturers.Interfaces.Queries
{
    public interface IManufacturerQueryRepository
    {
        Task<List<ManufacturerDto>> GetAllAsync(CancellationToken cancellationToken);

        Task<ManufacturerDto> GetAsync(int id, CancellationToken cancellationToken);
    }
}
