using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.WordGames;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class WordGamesController : BaseApiController
    {
        // --> move this part to the base class
        // private readonly IMediator _mediator;
        //
        // public WordGamesController(IMediator mediator)
        // {
        //     _mediator = mediator;
        // }

        [HttpGet]
        public async Task<ActionResult<List<WordGame>>> GetWordGames()
        {
            // return await _context.WordGames.ToListAsync();
            // return await _mediator.Send(new List.Query());
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WordGame>> GetWordGame(Guid id)
        {
            // return await _context.WordGames.FindAsync(id);
            return await Mediator.Send(new Details.Query
            {
                Id = id
            });
        }
    }
}