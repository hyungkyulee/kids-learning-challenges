using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

// KeyQ 2) repository role??
namespace Application.WordGames
{
    public class List
    {
        public class Query : IRequest<List<WordGame>> {}

        public class Handler : IRequestHandler<Query, List<WordGame>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            
            public async Task<List<WordGame>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.WordGames.ToListAsync();
            }
        }
    }
}