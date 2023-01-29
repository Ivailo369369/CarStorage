using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using CarStorage.Core.Application.Common.Behaviours;

using MediatR;
using FluentValidation;

namespace CarStorage.Core.Application
{
    public static class Dependencies
    {
        public static IServiceCollection ConfigureApplicationServices(
            this IServiceCollection services)
            => services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
    }
}
