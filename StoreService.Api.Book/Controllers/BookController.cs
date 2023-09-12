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

        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> Get()
        {
            try { 
                var books = await _mediator.Send(new Query.Execute());
                return Ok(books);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> Get(Guid id)
        {
            try
            {
                var book = await _mediator.Send(new QueryFilter.BookUnique { BookId = id});
                return Ok(book);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
