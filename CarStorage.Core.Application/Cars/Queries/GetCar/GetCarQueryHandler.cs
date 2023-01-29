using CarStorage.Core.Application.Common;
using CarStorage.Core.Application.Dtos.Cars;
using CarStorage.Core.Application.Common.Exceptions;
using CarStorage.Core.Application.Cars.Interfaces.Queries;

using MediatR;

namespace CarStorage.Core.Application.Cars.Queries.GetCar
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, Result<CarDto>>
    {
        private readonly ICarQueryRepository carQueryRepository;

        public GetCarQueryHandler(ICarQueryRepository carQueryRepository)
            => this.carQueryRepository = carQueryRepository;

        public async Task<Result<CarDto>> Handle(
            GetCarQuery request, 
            CancellationToken cancellationToken)
        {
            var result = await carQueryRepository.GetAsync(request.Id, cancellationToken);

            if (result == null)
            {
                return new NotFoundException(request.Id).Error;
            }

            return result;
        }
    }
}
