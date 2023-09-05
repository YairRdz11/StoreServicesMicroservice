using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Autor.Models;
using StoreService.Api.Autor.Persistent;

namespace StoreService.Api.Autor.Application
{
    public class QueryFilter
    {
        public class AutorUnique : IRequest<AutorBook>
        {
            public string AutorBookGuid { get; set; }
        }

        public class Handler : IRequestHandler<AutorUnique, AutorBook>
        {
            private readonly AutorContext _context;

            public Handler(AutorContext context) { _context = context; }
            public async Task<AutorBook> Handle(AutorUnique request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.AutorBookGuid))
                {
                    throw new ArgumentNullException(nameof(request.AutorBookGuid));
                }

                var autor = await _context.AutorBook.FirstOrDefaultAsync(x => x.AutorBookGuid == request.AutorBookGuid);

                if (autor == null)
                {
                    throw new ArgumentNullException($"Autor not found");
                }

                return autor;
            }
        }
    }
}
