using FluentValidation;

namespace CarStorage.Core.Application.Cars.Queries.GetCar
{
    public class GetCarQueryValidator : AbstractValidator<GetCarQuery>
    {
        public GetCarQueryValidator()
        {
            RuleFor(c => c.Id).NotEqual(x => default);
        }
    }
}
