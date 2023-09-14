using MediatR;
using StoreService.Api.ShoppingCart.Models;
using StoreService.Api.ShoppingCart.Persistant;

namespace StoreService.Api.ShoppingCart.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime DateCreationSession { get; set; }
            public List<string> Items { get; set; }
        }
        public class Handler : IRequestHandler<Execute>
        {
            private readonly ShoppingCartContext _context;
            public Handler(ShoppingCartContext context) 
            { 
                _context = context; 
            }
            public async Task Handle(Execute request, CancellationToken cancellationToken)
            {
                try
                {
                    var shoppingCartSession = new ShoppingCartSession
                    {
                        CreatedAt = request.DateCreationSession
                    };

                    _context.ShoppingCartSessions.Add(shoppingCartSession);

                    await _context.SaveChangesAsync();

                    foreach (var item in request.Items)
                    {
                        var shoppingCartSessionDetail = new ShoppingCartSessionDetail
                        {
                            ShoppingCartSessionId = shoppingCartSession.ShoppingCartSessionId,
                            SelectedProduct = item
                        };

                        _context.ShoppingCartSessionDetails.Add(shoppingCartSessionDetail);
                    }

                    await _context.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }


            }
        }
    }
}
