using CarStorage.Core.Domain.CarStorage;
using CarStorage.Core.Application.Dtos.Cars;
using CarStorage.Core.Application.Cars.Queries.GetCar;
using CarStorage.Core.Application.Cars.Queries.GetCars;

namespace CarStorage.Core.Application.Cars.Interfaces.Queries
{
    public interface ICarQueryRepository
    {
        public Task<CarDto> GetAsync(
            int id,
            CancellationToken cancellationToken);

        public Task<List<CarDto>> GetAllAsync(
            GetCarsQuery request, 
            CancellationToken cancellationToken);
    }
}
