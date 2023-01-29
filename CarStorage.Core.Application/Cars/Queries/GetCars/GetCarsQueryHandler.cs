using CarStorage.Core.Application.Dtos.Cars;
using CarStorage.Core.Application.Cars.Interfaces.Queries;

using MediatR;

namespace CarStorage.Core.Application.Cars.Queries.GetCars
{
    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<CarDto>>
    {
        private readonly ICarQueryRepository carQueryRepository;

        public GetCarsQueryHandler(ICarQueryRepository carQueryRepository)
            => this.carQueryRepository = carQueryRepository;

        public async Task<List<CarDto>> Handle(
            GetCarsQuery request, 
            CancellationToken cancellationToken)
        {
            var response = await carQueryRepository.GetAllAsync(request, cancellationToken);

            return response;
        }
    }
}
