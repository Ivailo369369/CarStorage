using CarStorage.Core.Application.Common;

using MediatR;

namespace CarStorage.Core.Application.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest<Result>
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
