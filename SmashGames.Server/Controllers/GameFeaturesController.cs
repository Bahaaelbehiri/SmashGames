using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmashGames.Server.Data;
using SmashGames.Server.Models;

namespace SmashGames.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameFeaturesController : ControllerBase
    {
        private readonly SmashContext _context;

        public GameFeaturesController(SmashContext context)
        {
            _context = context;
        }

        // GET: api/GameFeatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameFeature>>> GetGameFeatures()
        {
            return await _context.GameFeatures.ToListAsync();
        }

        // GET: api/GameFeatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameFeature>> GetGameFeature(int id)
        {
            var gameFeature = await _context.GameFeatures.FindAsync(id);

            if (gameFeature == null)
            {
                return NotFound();
            }

            return gameFeature;
        }

        // PUT: api/GameFeatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameFeature(int id, GameFeature gameFeature)
        {
            if (id != gameFeature.GameFeatureID)
            {
                return BadRequest();
            }

            _context.Entry(gameFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameFeatureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GameFeatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameFeature>> PostGameFeature(GameFeature gameFeature)
        {
            _context.GameFeatures.Add(gameFeature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameFeature", new { id = gameFeature.GameFeatureID }, gameFeature);
        }

        // DELETE: api/GameFeatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameFeature(int id)
        {
            var gameFeature = await _context.GameFeatures.FindAsync(id);
            if (gameFeature == null)
            {
                return NotFound();
            }

            _context.GameFeatures.Remove(gameFeature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameFeatureExists(int id)
        {
            return _context.GameFeatures.Any(e => e.GameFeatureID == id);
        }
    }
}
