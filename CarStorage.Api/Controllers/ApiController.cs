using Microsoft.AspNetCore.Mvc;

using MediatR;

namespace CarStorage.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator
            => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
