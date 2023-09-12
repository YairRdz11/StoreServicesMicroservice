using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Book.Models;
using StoreService.Api.Book.Persistant;

namespace StoreService.Api.Book.Application
{
    public class QueryFilter
    {
        public class BookUnique : IRequest<BookDTO>
        {
            public Guid BookId { get; set; }
        }

        public class Handler : IRequestHandler<BookUnique, BookDTO>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;

            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDTO> Handle(BookUnique request, CancellationToken cancellationToken)
            {
                try
                {
                    var book = await _context.Library.FirstOrDefaultAsync(x => x.LibraryId == request.BookId);
                    if (book == null)
                    {
                        throw new Exception("Book not found");
                    }
                    var bookDTO = _mapper.Map<Library,BookDTO>(book);

                    return bookDTO;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
