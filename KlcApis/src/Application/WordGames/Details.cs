using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WordGames
{
    public class Details
    {
        // KeyQ 3) Request Class? 
        public class Query : IRequest<WordGame>
        {
            public Guid Id;
        }

        public class Handler : IRequestHandler<Query, WordGame>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<WordGame> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.WordGames.FindAsync(request.Id);
            }
        }
    }
}