namespace CarStorage.Infrastructure.Repositories.Queries
{
    using Microsoft.EntityFrameworkCore;

    using CarStorage.Infrastructure.Data;
    using CarStorage.Core.Application.Dtos.Categories;
    using CarStorage.Core.Application.Categories.Interfaces.Queries;

    using AutoMapper;

    public class CategoryQueryRepository : ICategoryQyeryRepository
    {
        private readonly IMapper mapper;
        private readonly ICarStorageDbContext dbContext;

        public CategoryQueryRepository(
            IMapper mapper,
            ICarStorageDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var categories = await dbContext
                .Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var result = mapper.Map<List<CategoryDto>>(categories);

            return result;
        }

        public async Task<CategoryDto> GetAsync(int id, CancellationToken cancellationToken)
        {
            var category = await dbContext
                .Categories
                .AsNoTracking()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            var result = mapper.Map<CategoryDto>(category);

            return result;
        }
    }
}
