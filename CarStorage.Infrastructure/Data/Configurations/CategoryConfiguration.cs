using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CarStorage.Infrastructure.Configurations;
using CarStorage.Core.Domain.CarStorage.Entities;

namespace CarStorage.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasMaxLength(Constants.DataConstants.MaxNameLength)
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasMaxLength(Constants.DataConstants.MaxDescriptionLength);
        }
    }
}
