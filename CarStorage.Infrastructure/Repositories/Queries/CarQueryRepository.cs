using Microsoft.EntityFrameworkCore;

using CarStorage.Infrastructure.Data;
using CarStorage.Core.Domain.CarStorage;
using CarStorage.Core.Application.Dtos.Cars;
using CarStorage.Core.Application.Cars.Queries.GetCars;
using CarStorage.Core.Application.Cars.Interfaces.Queries;

using AutoMapper;

namespace CarStorage.Infrastructure.Repositories.Queries
{
    public class CarQueryRepository : ICarQueryRepository
    {
        private readonly IMapper mapper;
        private readonly ICarStorageDbContext dbContext;

        public CarQueryRepository(
            IMapper mapper,
            ICarStorageDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<List<CarDto>> GetAllAsync(
            GetCarsQuery request, 
            CancellationToken cancellationToken)
        {
            var query = dbContext
                .Cars
                .AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.Manufacturer)
                .AsQueryable();

            if (string.IsNullOrEmpty(request.Model))
            {
                query = query.Where(c => c.Model.Contains(request.Model));
            }

            if (request.CategoryId != default)
            {
                query = query.Where(c => c.CategoryId == request.CategoryId);
            }

            if (request.ManufacturerId != default)
            {
                query = query.Where(c => c.ManufacturerId == request.ManufacturerId);
            }

            var cars = await query
                .Skip((int)request.Skip)
                .Take((int)request.Take)
                .ToListAsync(cancellationToken);

            var result = mapper.Map<List<CarDto>>(cars);

            return result;
        }

        public async Task<CarDto> GetAsync(
            int id,
            CancellationToken cancellationToken)
        {
            var cars = await dbContext
                .Cars
                .AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.Manufacturer)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            var result = mapper.Map<CarDto>(cars);

            return result;
        }
    }
}
