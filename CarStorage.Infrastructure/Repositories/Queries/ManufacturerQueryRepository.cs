using Microsoft.EntityFrameworkCore;

using CarStorage.Infrastructure.Data;
using CarStorage.Core.Application.Dtos.Manufacturers;
using CarStorage.Core.Application.Manufacturers.Interfaces.Queries;

using AutoMapper;

namespace CarStorage.Infrastructure.Repositories.Queries
{
    public class ManufacturerQueryRepository : IManufacturerQueryRepository
    {
        private readonly IMapper mapper;
        private readonly ICarStorageDbContext dbContext;

        public ManufacturerQueryRepository(
            IMapper mapper, 
            ICarStorageDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<List<ManufacturerDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var manufacturers = await dbContext
                .Manufacturers
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var result = mapper.Map<List<ManufacturerDto>>(manufacturers);

            return result;
        }

        public async Task<ManufacturerDto> GetAsync(int id, CancellationToken cancellationToken)
        {
            var manufacturer = await dbContext
                .Manufacturers
                .AsNoTracking()
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            var result = mapper.Map<ManufacturerDto>(manufacturer);

            return result;
        }
    }
}
