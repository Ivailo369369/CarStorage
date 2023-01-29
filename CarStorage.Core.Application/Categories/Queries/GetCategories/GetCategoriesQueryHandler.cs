using CarStorage.Core.Application.Dtos.Categories;
using CarStorage.Core.Application.Categories.Interfaces.Queries;

using MediatR;

namespace CarStorage.Core.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryQyeryRepository categoryQyeryRepository;

        public GetCategoriesQueryHandler(ICategoryQyeryRepository categoryQyeryRepository)
            => this.categoryQyeryRepository = categoryQyeryRepository;

        public async Task<List<CategoryDto>> Handle(
            GetCategoriesQuery request, 
            CancellationToken cancellationToken)
        {
            var categories = await categoryQyeryRepository.GetAllAsync(cancellationToken);

            return categories;
        }
    }
}
