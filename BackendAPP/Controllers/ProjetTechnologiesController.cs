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
    public class ProjetTechnologiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjetTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjetTechnologies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetTechnologie>>> GetProjetTechnologie()
        {
            return await _context.ProjetTechnologie.ToListAsync();
        }

        // GET: api/ProjetTechnologies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetTechnologie>> GetProjetTechnologie(long id)
        {
            var projetTechnologie = await _context.ProjetTechnologie.FindAsync(id);

            if (projetTechnologie == null)
            {
                return NotFound();
            }

            return projetTechnologie;
        }

        // PUT: api/ProjetTechnologies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjetTechnologie(long id, ProjetTechnologie projetTechnologie)
        {
            if (id != projetTechnologie.id_projet)
            {
                return BadRequest();
            }

            _context.Entry(projetTechnologie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetTechnologieExists(id))
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

        // POST: api/ProjetTechnologies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjetTechnologie>> PostProjetTechnologie(ProjetTechnologie projetTechnologie)
        {
            _context.ProjetTechnologie.Add(projetTechnologie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjetTechnologieExists(projetTechnologie.id_projet))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjetTechnologie", new { id = projetTechnologie.id_projet }, projetTechnologie);
        }

        // DELETE: api/ProjetTechnologies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjetTechnologie(long id)
        {
            var projetTechnologie = await _context.ProjetTechnologie.FindAsync(id);
            if (projetTechnologie == null)
            {
                return NotFound();
            }

            _context.ProjetTechnologie.Remove(projetTechnologie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetTechnologieExists(long id)
        {
            return _context.ProjetTechnologie.Any(e => e.id_projet == id);
        }
    }
}
