using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Autor.Models;
using StoreService.Api.Autor.Persistent;

namespace StoreService.Api.Autor.Application
{
    public class Query
    {
        public class AutorList : IRequest<List<AutorBook>>
        {

        }

        public class Handler : IRequestHandler<AutorList, List<AutorBook>>
        {
            private readonly AutorContext _context;
            public Handler(AutorContext context)
            {
                _context = context;
            }

            public async Task<List<AutorBook>> Handle(AutorList request, CancellationToken cancellationToken)
            {
                return await _context.AutorBook.ToListAsync();
            }
        }
    }
}
