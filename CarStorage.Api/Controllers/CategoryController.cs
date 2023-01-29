using System.Net;

using Microsoft.AspNetCore.Mvc;

using CarStorage.Api.Models.Categories;
using CarStorage.Core.Application.Categories.Queries.GetCategories;

using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace CarStorage.Api.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly IMapper mapper;

        public CategoryController(IMapper mapper)
            => this.mapper = mapper;

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get categories",
            Description = "Get categories",
            OperationId = "GetAllAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, type: typeof(List<ApiCategoryModel>))]
        public async Task<ActionResult<List<ApiCategoryModel>>> GetAllAsync()
        {
            var response = await Send(new GetCategoriesQuery());

            var result = mapper.Map<List<ApiCategoryModel>>(response);

            return result;
        }
    }
}
