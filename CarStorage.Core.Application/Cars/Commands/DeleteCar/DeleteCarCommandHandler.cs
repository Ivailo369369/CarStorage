using CarStorage.Core.Application.Common;
using CarStorage.Core.Application.Common.Exceptions;
using CarStorage.Core.Domain.CarStorage.Repositories;

using MediatR;

namespace CarStorage.Core.Application.Cars.Commands.DeleteCar
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Result>
    {
        private readonly ICarDomainRepository carDomainRepository;

        public DeleteCarCommandHandler(ICarDomainRepository carDomainRepository)
            => this.carDomainRepository = carDomainRepository;

        public async Task<Result> Handle(
            DeleteCarCommand request, 
            CancellationToken cancellationToken)
        {
            var car = await carDomainRepository.GetAsync(request.Id, cancellationToken);

            if (car == null) 
            {
                return new NotFoundException(request.Id).Error;
            }

            await carDomainRepository.DeleteCarAsync(car, cancellationToken);

            return Result.Success;
        }
    }
}
