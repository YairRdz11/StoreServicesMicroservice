using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreService.Api.ShoppingCart.Application;

namespace StoreService.Api.ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post(New.Execute data)
        {
            try
            {
                await _mediator.Send(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult<ShoppingCartDTO>> Get(int id)
        {
            try
            {
                var shoppingCart = await _mediator.Send(new Query.Execute { shoppingSessionId = id });
                return Ok(shoppingCart);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
