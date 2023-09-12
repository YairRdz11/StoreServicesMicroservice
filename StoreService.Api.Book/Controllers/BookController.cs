using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreService.Api.Book.Application;

namespace StoreService.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator) { _mediator = mediator; }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] New.Execute book)
        {
            try
            {
                await _mediator.Send(book);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
