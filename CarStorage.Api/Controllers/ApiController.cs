using Microsoft.AspNetCore.Mvc;

using CarStorage.Api.Common;
using CarStorage.Core.Application.Common;

using MediatR;

namespace CarStorage.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator mediator;

        protected IMediator Mediator
            => this.mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult> Send(IRequest<Result> request)
            => this.Mediator.Send(request).ToActionResult();

        protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
            => this.Mediator.Send(request).ToActionResult();
    }
}
