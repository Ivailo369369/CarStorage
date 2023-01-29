using CarStorage.Core.Application.Common;
using CarStorage.Core.Application.Common.Exceptions;
using CarStorage.Core.Domain.CarStorage.Repositories;

using MediatR;

namespace CarStorage.Core.Application.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Result>
    {
        private readonly ICarDomainRepository carDomainRepository;

        public UpdateCarCommandHandler(ICarDomainRepository carDomainRepository)
            => this.carDomainRepository = carDomainRepository;

        public async Task<Result> Handle(
            UpdateCarCommand request, 
            CancellationToken cancellationToken)
        {
            var car = await carDomainRepository.GetAsync(request.Id, cancellationToken);

            if (car == null)
            {
                return new NotFoundException(request.Id).Error;
            }

            car.UpdateModel(request.Model)
                .UpdateImageUrl(request.ImageUrl)
                .UpdateDescription(request.Description);

            await carDomainRepository.UpdateAsync(car, cancellationToken);

            return Result.Success;
        }
    }
}
