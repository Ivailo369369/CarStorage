using CarStorage.Core.Application.Dtos.Categories;

namespace CarStorage.Core.Application.Categories.Interfaces.Queries
{
    public interface ICategoryQyeryRepository
    {
        Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken);

        Task<CategoryDto> GetAsync(int id, CancellationToken cancellationToken);
    }
}
