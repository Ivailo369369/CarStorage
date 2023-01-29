using CarStorage.Core.Application.Common;

using MediatR;

namespace CarStorage.Core.Application.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
