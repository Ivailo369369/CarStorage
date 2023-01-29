using CarStorage.Core.Application.Dtos.Manufacturers;
using CarStorage.Core.Application.Manufacturers.Interfaces.Queries;

using MediatR;

namespace CarStorage.Core.Application.Manufacturers.Queries.GetManufacturers
{
    public class GetManufacturerQueryHandler : IRequestHandler<GetManufacturerQuery, List<ManufacturerDto>>
    {
        private readonly IManufacturerQueryRepository manufacturerQueryRepository;

        public GetManufacturerQueryHandler(IManufacturerQueryRepository manufacturerQueryRepository)
            => this.manufacturerQueryRepository = manufacturerQueryRepository;

        public async Task<List<ManufacturerDto>> Handle(
            GetManufacturerQuery request, 
            CancellationToken cancellationToken)
        {
            var manufacturers = await manufacturerQueryRepository.GetAllAsync(cancellationToken);

            return manufacturers;
        }
    }
}
