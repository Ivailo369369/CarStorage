using CarStorage.Core.Application.Dtos.Categories;

using MediatR;

namespace CarStorage.Core.Application.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
    }
}
