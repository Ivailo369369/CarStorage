using System.Net;

using Microsoft.AspNetCore.Mvc;

using CarStorage.Api.Models.Manufacturers;
using CarStorage.Core.Application.Manufacturers.Queries.GetManufacturers;

using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace CarStorage.Api.Controllers
{
    public class ManufacturerController : ApiController
    {
        private readonly IMapper mapper;

        public ManufacturerController(IMapper mapper)
            => this.mapper = mapper;

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get manufacturers",
            Description = "Get manufacturers",
            OperationId = "GetAllAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, type: typeof(List<ApiManufacturerModel>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await Mediator.Send(new GetManufacturerQuery());

            var result = mapper.Map<List<ApiManufacturerModel>>(response);

            return Ok(result);
        }
    }
}
