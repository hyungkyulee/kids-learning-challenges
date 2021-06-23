using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.WordGames
{
    public class Create
    {
        public class Command : IRequest
        {
            public WordGame WordGame;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }


            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _dataContext.WordGames.Add(request.WordGame);
                await _dataContext.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}