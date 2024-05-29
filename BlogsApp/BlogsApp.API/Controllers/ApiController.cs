using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
