using Microsoft.EntityFrameworkCore;

using CarStorage.Infrastructure.Data;
using CarStorage.Core.Domain.CarStorage.Entities;
using CarStorage.Core.Domain.CarStorage.Repositories;

using AutoMapper;

namespace CarStorage.Infrastructure.Repositories
{
    public class CarRepository : ICarDomainRepository
    {
        private readonly ICarStorageDbContext dbContext;

        public CarRepository(ICarStorageDbContext dbContext)
            => this.dbContext = dbContext;

        public async Task<Car> GetAsync(
            int id, 
            CancellationToken cancellationToken)
        {
            var car = await dbContext.Cars
                .AsNoTracking()
                .Include(c => c.Category)
                .Include(c => c.Manufacturer)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return car;
        }

        public async Task<int> CreateAsync(
            Car car, 
            CancellationToken cancellationToken)
        {
            var newEntry = await dbContext.Cars.AddAsync(car, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return newEntry.Entity.Id;
        }

        public async Task DeleteCarAsync(
            Car car, 
            CancellationToken cancellationToken)
        {
            dbContext.Cars.Remove(car);

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(
            Car car, 
            CancellationToken cancellationToken)
        {
            dbContext.Cars.Update(car);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
