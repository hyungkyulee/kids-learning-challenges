using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class WordGamesController : BaseApiController
    {
        private readonly DataContext _context;

        public WordGamesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<WordGame>>> GetWordGames()
        {
            return await _context.WordGames.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WordGame>> GetWordGame(Guid id)
        {
            return await _context.WordGames.FindAsync(id);
        }
    }
}