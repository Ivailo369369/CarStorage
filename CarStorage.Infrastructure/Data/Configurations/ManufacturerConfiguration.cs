using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CarStorage.Infrastructure.Configurations;
using CarStorage.Core.Domain.CarStorage.Entities;

namespace CarStorage.Infrastructure.Data.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .HasMaxLength(Constants.DataConstants.MaxNameLength)
                .IsRequired();
        }
    }
}
