using System.Net;

using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetCarQuery { Id = id });

            if (!response.Succeeded)
            {
                return NotFound(response.Errors);
            }

            var result = mapper.Map<ApiCarModel>(response);

            return Ok(result);
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Get cars",
            Description = "Get cars with a filtering option",
            OperationId = "GetAllAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK, type: typeof(List<ApiCarModel>))]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetCarsQuery query)
        {
            var response = await Mediator.Send(query);

            var result = mapper.Map<List<ApiCarModel>>(response);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create car",
            Description = "Create car",
            OperationId = "CreateAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.Created)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCarCommand command)
        {
            var response = await Mediator.Send(command);

            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Update a car",
            Description = "Update a car",
            OperationId = "UpdateAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.OK)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateAsync(
            [FromRoute] int id,
            [FromBody] UpdateCarCommand command)
        {
            command.Id = id;

            var response = await Mediator.Send(command);

            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        [HttpDelete]
        [SwaggerOperation(
            Summary = "Delete a car",
            Description = "Delete car",
            OperationId = "DeleteAsync")]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NoContent)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.NotFound)]
        [SwaggerResponse(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteCarCommand() { Id = id });

            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }

            return NoContent();
        }
    }
}
