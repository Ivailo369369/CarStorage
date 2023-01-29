using CarStorage.Core.Domain.Common.Constants;
using CarStorage.Core.Application.Categories.Interfaces.Queries;
using CarStorage.Core.Application.Manufacturers.Interfaces.Queries;

using FluentValidation;

namespace CarStorage.Core.Application.Cars.Commands.CreateCar
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator(
            ICategoryQyeryRepository categoryQyeryRepository,
            IManufacturerQueryRepository manufacturerQueryRepository)
        {
            RuleFor(c => c.Model)
                .NotNull()
                .MaximumLength(ModelConstants.Common.MaxModelLength);

            RuleFor(c => c.Description)
                .MaximumLength(ModelConstants.Common.MaxDescriptionLength);

            RuleFor(c => c.ImageUrl)
                .MaximumLength(ModelConstants.Common.MaxImageUrlLenght);

            RuleFor(c => c.CategoryId)
                .NotNull()
                .MustAsync(async (category, token) 
                    => await categoryQyeryRepository.GetAsync(category, token) != null)
                .WithMessage("This category does not exist.");

            RuleFor(c => c.ManufacturerId)
                .NotNull()
                .MustAsync(async (manufacturer, token) 
                    => await manufacturerQueryRepository.GetAsync(manufacturer, token) != null)
                .WithMessage("This manufacturer does not exist.");
        }
    }
}
