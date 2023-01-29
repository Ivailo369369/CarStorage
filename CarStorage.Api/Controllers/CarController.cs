using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CarStorage.Api.Models.Cars;
using CarStorage.Core.Application.Cars.Queries.GetCar;
using CarStorage.Core.Application.Cars.Queries.GetCars;
using CarStorage.Core.Application.Cars.Commands.UpdateCar;
using CarStorage.Core.Application.Cars.Commands.CreateCar;
using CarStorage.Core.Application.Cars.Commands.DeleteCar;

using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace CarStorage.Api.Controllers
{
    public class CarController : ApiController
    {
        private readonly IMapper mapper;

        public CarController(IMapper mapper)
            => this.mapper = mapper;

        [HttpGet("{Id}")]
        [SwaggerOperation(
            Summary = "Get a car",
            Description = "Get a car by id",
            OperationId = "GetAsync")]
        [SwaggerResponse(statusCode: (int) HttpStatusCode.OK, type: typeof(ApiCarModel))]
        public async Task<ActionResult<ApiCarModel>> GetAsync([FromRoute] int id)
        {
            var response = await Send(new GetCarQuery { Id = id });

            var result = mapper.Map<ActionResult<ApiCarModel>>(response);

            return result;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get cars",
            Description = "Get cars with a filtering option",
            OperationId = "GetAllAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, type: typeof(List<ApiCarModel>))]
        public async Task<ActionResult<List<ApiCarModel>>> GetAllAsync([FromQuery] GetCarsQuery query)
        {
            var response = await Send(query);

            var result = mapper.Map<ActionResult<List<ApiCarModel>>>(response);

            return result;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create car",
            Description = "Create car",
            OperationId = "CreateAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.Created)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCarCommand command)
            => await Send(command);

        [HttpPut]
        [SwaggerOperation(
            Summary = "Update a car",
            Description = "Update a car",
            OperationId = "UpdateAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.Created)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateAsync(
            [FromRoute] int id,
            [FromBody] UpdateCarCommand command)
        {
            command.Id = id;

            var response = await Send(command);

            return response;
        }

        [HttpDelete]
        [SwaggerOperation(
            Summary = "Delete a car",
            Description = "Delete car",
            OperationId = "DeleteAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
            => await Send(new DeleteCarCommand() { Id = id });
    }
}
