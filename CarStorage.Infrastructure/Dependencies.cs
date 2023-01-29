using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CarStorage.Infrastructure.Data;
using CarStorage.Infrastructure.Repositories;
using CarStorage.Core.Application.Configurations;
using CarStorage.Core.Domain.CarStorage.Repositories;
using CarStorage.Infrastructure.Repositories.Queries;
using CarStorage.Core.Application.Cars.Interfaces.Queries;
using CarStorage.Core.Application.Categories.Interfaces.Queries;
using CarStorage.Core.Application.Manufacturers.Interfaces.Queries;

namespace CarStorage.Infrastructure
{
    public static class Dependencies
    {
        private static GlobalConfiguration GlobalConfigurations;

        public static IServiceCollection ConfigureInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddConfiguration(configuration)
                .AddDatabase()
                .AddScoped<ICarStorageDbContext>(provider => provider.GetService<CarStorageDbContext>())
                .AddScoped<ICarQueryRepository, CarQueryRepository>()
                .AddScoped<ICategoryQyeryRepository, CategoryQueryRepository>()
                .AddScoped<IManufacturerQueryRepository, ManufacturerQueryRepository>()
                .AddScoped<ICarDomainRepository, CarRepository>();

        private static IServiceCollection AddConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<GlobalConfiguration>(
                configuration.GetSection(nameof(GlobalConfiguration)));

            GlobalConfigurations = configuration
                .GetSection(nameof(GlobalConfiguration))
                .Get<GlobalConfiguration>();

            return services;
        }

        private static IServiceCollection AddDatabase(
           this IServiceCollection services)
            => services.AddDbContext<CarStorageDbContext>(options =>
                options.UseSqlServer(GlobalConfigurations.CarStorageDbContext.ConnectionString));
    }
}
