using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Autor.Models;
using StoreService.Api.Autor.Persistent;

namespace StoreService.Api.Autor.Application
{
    public class Query
    {
        public class AutorList : IRequest<List<AutorDTO>>
        {

        }

        public class Handler : IRequestHandler<AutorList, List<AutorDTO>>
        {
            private readonly AutorContext _context;
            private readonly IMapper _autoMapper;
            public Handler(AutorContext context, IMapper mapper)
            {
                _context = context;
                _autoMapper = mapper;
            }

            public async Task<List<AutorDTO>> Handle(AutorList request, CancellationToken cancellationToken)
            {
                var autorsDB = await _context.AutorBook.ToListAsync();
                var autorsDTO = _autoMapper.Map<List<AutorBook>, List<AutorDTO>>(autorsDB);

                return autorsDTO;
            }
        }
    }
}
