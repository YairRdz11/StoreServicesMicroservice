using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Autor.Models;
using StoreService.Api.Autor.Persistent;

namespace StoreService.Api.Autor.Application
{
    public class QueryFilter
    {
        public class AutorUnique : IRequest<AutorDTO>
        {
            public string AutorBookGuid { get; set; }
        }

        public class Handler : IRequestHandler<AutorUnique, AutorDTO>
        {
            private readonly AutorContext _context;
            private readonly IMapper _mapper;

            public Handler(AutorContext context, IMapper mapper) 
            { 
                _context = context;
                _mapper = mapper;
            }
            public async Task<AutorDTO> Handle(AutorUnique request, CancellationToken cancellationToken)
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

                var autorDTO = _mapper.Map<AutorBook, AutorDTO>(autor);

                return autorDTO;
            }
        }
    }
}
