using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreService.Api.Autor.Application;
using StoreService.Api.Autor.Models;

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

        [HttpGet]
        public async Task<List<AutorBook>> Get()
        {
            return await _mediator.Send(new Query.AutorList());
        }
    }
}
