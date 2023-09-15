using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.ShoppingCart.Persistant;
using StoreService.Api.ShoppingCart.RemoteInterfaces;

namespace StoreService.Api.ShoppingCart.Application
{
    public class Query
    {
        public class Execute : IRequest<ShoppingCartDTO>
        {
            public int shoppingSessionId { get; set; }
        }
        public class Handler : IRequestHandler<Execute, ShoppingCartDTO>
        {
            private readonly ShoppingCartContext _context;
            private readonly IBookService _bookService;

            public Handler(ShoppingCartContext context, IBookService bookService)
            {
                _context = context;
                _bookService = bookService;
            }

            public async Task<ShoppingCartDTO> Handle(Execute request, CancellationToken cancellationToken)
            {
                try
                {
                    List<ShoppingDetailDTO> shoppingDetailDTOs = new List<ShoppingDetailDTO>();

                    var shoppingCart = await _context.ShoppingCartSessions
                    .FirstOrDefaultAsync(x => x.ShoppingCartSessionId == request.shoppingSessionId);

                    if (shoppingCart == null)
                    {
                        throw new Exception("Not found");
                    }
                    var shoppingCartSessionDetailList = await _context.ShoppingCartSessionDetails
                        .Where(x => x.ShoppingCartSessionId == request.shoppingSessionId).ToListAsync();

                    foreach(var book in shoppingCartSessionDetailList)
                    {
                        var response = await _bookService.GetBook(new Guid(book.SelectedProduct));
                        if (response.result)
                        {
                            var objBook = response.remoteBook;
                            var shoppingCartDetail = new ShoppingDetailDTO
                            {
                                BookId = objBook.LibraryId,
                                PublishDate = objBook.PublishDate,
                                TitleBook = objBook.Title,
                            };

                            shoppingDetailDTOs.Add(shoppingCartDetail);
                        }
                    }

                    var shoppingCartDTO = new ShoppingCartDTO
                    {
                        ShoppingCartId = shoppingCart.ShoppingCartSessionId,
                        CreatedDateSession = shoppingCart.CreatedAt,
                        Items = shoppingDetailDTOs
                    };

                    return shoppingCartDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                

            }
        }
    }
}
