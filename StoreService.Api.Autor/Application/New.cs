using MediatR;
using StoreService.Api.Autor.Models;
using StoreService.Api.Autor.Persistent;

namespace StoreService.Api.Autor.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? Birthdate { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly AutorContext _context;
            public Handler(AutorContext context)
            {
                _context = context;
            }
            public async Task Handle(Execute request, CancellationToken cancellationToken)
            {
                var autorBook = new AutorBook
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Birthdate = request.Birthdate,
                    AutorBookGuid = Guid.NewGuid().ToString()
                };
                try
                {
                    _context.AutorBook.Add(autorBook);

                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
