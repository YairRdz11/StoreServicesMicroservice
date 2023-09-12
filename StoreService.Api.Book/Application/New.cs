using FluentValidation;
using MediatR;
using StoreService.Api.Book.Models;
using StoreService.Api.Book.Persistant;

namespace StoreService.Api.Book.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime PublishDate { get; set; }
            public Guid AutorBook { get; set; }
        }

        public class ExecuteValidator : AbstractValidator<Execute>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublishDate).NotEmpty();
                RuleFor(x => x.AutorBook).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly BookContext _context;

            public Handler(BookContext context)
            {
                _context = context;
            }

            public async Task Handle(Execute request, CancellationToken cancellationToken)
            {
                try
                {
                    var book = new Library
                    {
                        Title = request.Title,
                        PublishDate = request.PublishDate,
                        AutorBook = request.AutorBook
                    };

                    _context.Library.Add(book);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw new Exception($"The book {request.Title} can not be added");
                }
            }
        }
    }
}
