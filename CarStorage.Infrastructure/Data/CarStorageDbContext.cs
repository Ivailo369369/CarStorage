using System.Reflection;

using Microsoft.EntityFrameworkCore;

using CarStorage.Core.Domain.CarStorage.Entities;

namespace CarStorage.Infrastructure.Data
{
    public class CarStorageDbContext : DbContext, ICarStorageDbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
