using CarStorage.Core.Domain.CarStorage.Entities;

namespace CarStorage.Core.Domain.CarStorage.Repositories
{
    public interface ICarDomainRepository
    {
        Task<Car> GetAsync(int id, CancellationToken cancellationToken);

        Task<int> CreateAsync(Car car, CancellationToken cancellationToken);

        Task UpdateAsync(Car car, CancellationToken cancellationToken);

        Task DeleteCarAsync(Car car, CancellationToken cancellationToken);
    }
}
