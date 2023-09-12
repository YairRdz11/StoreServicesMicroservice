

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Book.Models;
using StoreService.Api.Book.Persistant;

namespace StoreService.Api.Book.Application
{
    public class Query
    {
        public class Execute : IRequest<List<BookDTO>> { }
        public class Handler : IRequestHandler<Execute, List<BookDTO>>
        {
            private readonly BookContext _context;
            private readonly IMapper _mapper;
            public Handler(BookContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<BookDTO>> Handle(Execute request, CancellationToken cancellationToken)
            {
                try
                {
                    var books = await _context.Library.ToListAsync();

                    var booksDTO = _mapper.Map<List<Library>, List<BookDTO>>(books);

                    return booksDTO;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
