using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreService.Api.Autor.Application;

namespace StoreService.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create(New.Execute data)
        {
            await _mediator.Send(data);
        }
    }
}
