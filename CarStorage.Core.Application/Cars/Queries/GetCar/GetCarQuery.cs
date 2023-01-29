using CarStorage.Core.Application.Common;
using CarStorage.Core.Application.Dtos.Cars;

using MediatR;

namespace CarStorage.Core.Application.Cars.Queries.GetCar
{
    public class GetCarQuery : IRequest<Result<CarDto>>
    {
        public int Id { get; set; }
    }
}
