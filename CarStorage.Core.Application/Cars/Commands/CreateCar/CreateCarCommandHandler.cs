using CarStorage.Core.Application.Common;

using CarStorage.Core.Domain.CarStorage.Entities;
using CarStorage.Core.Domain.CarStorage.Repositories;

using MediatR;

namespace CarStorage.Core.Application.Cars.Commands.CreateCar
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Result>
    {
        private readonly ICarDomainRepository carDomainRepository;

        public CreateCarCommandHandler(ICarDomainRepository carDomainRepository)
            => this.carDomainRepository = carDomainRepository;

        public async Task<Result> Handle(
            CreateCarCommand request, 
            CancellationToken cancellationToken)
        {
            var car = Car.Create(
                request.Model,
                request.ImageUrl,
                request.Description,
                request.CategoryId,
                request.ManufacturerId);

            await carDomainRepository.CreateAsync(car, cancellationToken);

            return Result.Success;
        }
    }
}
