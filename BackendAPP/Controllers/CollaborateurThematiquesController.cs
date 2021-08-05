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
    public class CollaborateurThematiquesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CollaborateurThematiquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CollaborateurThematiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollaborateurThematique>>> GetCollaborateurThematique()
        {
            return await _context.CollaborateurThematique.ToListAsync();
        }

        // GET: api/CollaborateurThematiques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollaborateurThematique>> GetCollaborateurThematique(long id)
        {
            var collaborateurThematique = await _context.CollaborateurThematique.FindAsync(id);

            if (collaborateurThematique == null)
            {
                return NotFound();
            }

            return collaborateurThematique;
        }

        // PUT: api/CollaborateurThematiques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollaborateurThematique(long id, CollaborateurThematique collaborateurThematique)
        {
            if (id != collaborateurThematique.Id_Thematique)
            {
                return BadRequest();
            }

            _context.Entry(collaborateurThematique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollaborateurThematiqueExists(id))
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

        // POST: api/CollaborateurThematiques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollaborateurThematique>> PostCollaborateurThematique(CollaborateurThematique collaborateurThematique)
        {
            _context.CollaborateurThematique.Add(collaborateurThematique);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CollaborateurThematiqueExists(collaborateurThematique.Id_Thematique))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCollaborateurThematique", new { id = collaborateurThematique.Id_Thematique }, collaborateurThematique);
        }

        // DELETE: api/CollaborateurThematiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaborateurThematique(long id)
        {
            var collaborateurThematique = await _context.CollaborateurThematique.FindAsync(id);
            if (collaborateurThematique == null)
            {
                return NotFound();
            }

            _context.CollaborateurThematique.Remove(collaborateurThematique);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollaborateurThematiqueExists(long id)
        {
            return _context.CollaborateurThematique.Any(e => e.Id_Thematique == id);
        }
    }
}
