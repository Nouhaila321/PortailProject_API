using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPP.Models;

namespace BackendAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Poles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pole>>> GetPole()
        {
            return await _context.Pole.ToListAsync();
        }

        // GET: api/Poles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pole>> GetPole(long id)
        {
            var pole = await _context.Pole.FindAsync(id);

            if (pole == null)
            {
                return NotFound();
            }

            return pole;
        }

        // PUT: api/Poles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPole(long id, Pole pole)
        {
            if (id != pole.Id_Pole)
            {
                return BadRequest();
            }

            _context.Entry(pole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoleExists(id))
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

        // POST: api/Poles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pole>> PostPole(Pole pole)
        {
            _context.Pole.Add(pole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPole", new { id = pole.Id_Pole }, pole);
        }

        // DELETE: api/Poles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePole(long id)
        {
            var pole = await _context.Pole.FindAsync(id);
            if (pole == null)
            {
                return NotFound();
            }

            _context.Pole.Remove(pole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoleExists(long id)
        {
            return _context.Pole.Any(e => e.Id_Pole == id);
        }
    }
}
