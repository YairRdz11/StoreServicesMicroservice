using MediatR;
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

        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> Get()
        {
            try
            {
                return await _mediator.Send(new Query.AutorList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{guidId}")]
        public async Task<ActionResult<AutorDTO>> Get(string guid)
        {
            try
            {
                if (string.IsNullOrEmpty(guid))
                {
                    throw new ArgumentNullException(nameof(guid));
                }
                return await _mediator.Send(new QueryFilter.AutorUnique { AutorBookGuid = guid});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
