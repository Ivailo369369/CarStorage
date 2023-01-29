using CarStorage.Core.Application.Common;

using MediatR;

namespace CarStorage.Core.Application.Cars.Commands.CreateCar
{
    public class CreateCarCommand : IRequest<Result>
    {
        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public int CategoryId { get; set; }
    }
}
