using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CarStorage.Infrastructure.Configurations;
using CarStorage.Core.Domain.CarStorage.Entities;

namespace CarStorage.Infrastructure.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Model)
                .HasMaxLength(Constants.DataConstants.MaxModelLength)
                .IsRequired();

            builder
                .Property(c => c.ImageUrl)
                .HasMaxLength(Constants.DataConstants.MaxImageUrlLength)
                .IsRequired();

            builder
                .Property(c => c.ManufacturerId)
                .IsRequired();

            builder
                .Property(c => c.CategoryId)
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasMaxLength(Constants.DataConstants.MaxDescriptionLength);

            builder
                .HasOne(c => c.Manufacturer)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
