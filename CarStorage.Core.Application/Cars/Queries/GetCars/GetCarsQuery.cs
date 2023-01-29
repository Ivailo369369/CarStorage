using CarStorage.Core.Application.Dtos.Cars;

using MediatR;

namespace CarStorage.Core.Application.Cars.Queries.GetCars
{
    public class GetCarsQuery : IRequest<List<CarDto>>
    {
        public string Model { get; set; }

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public int? Skip { get; set; }

        public int? Take { get; set; }
    }
}
