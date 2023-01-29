using Microsoft.EntityFrameworkCore;

using CarStorage.Core.Domain.CarStorage.Entities;

namespace CarStorage.Infrastructure.Data
{
    public interface ICarStorageDbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
