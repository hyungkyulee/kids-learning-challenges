using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        // KeyQ 1)
        protected IMediator Mediator => _mediator ??= HttpContext
            .RequestServices
            .GetService<IMediator>();

        protected IMediator Mediator1
        {
            get
            {
                return _mediator ??= HttpContext
                    .RequestServices
                    .GetService<IMediator>();
            }
        }
    }
}