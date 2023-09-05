using MediatR;

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
            public Task Handle(Execute request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
