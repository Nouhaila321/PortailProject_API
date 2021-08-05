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
    public class CollaborateurTechnologiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CollaborateurTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CollaborateurTechnologies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollaborateurTechnologie>>> GetCollaborateurTechnologie()
        {
            return await _context.CollaborateurTechnologie.ToListAsync();
        }

        // GET: api/CollaborateurTechnologies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollaborateurTechnologie>> GetCollaborateurTechnologie(string id)
        {
            var collaborateurTechnologie = await _context.CollaborateurTechnologie.FindAsync(id);

            if (collaborateurTechnologie == null)
            {
                return NotFound();
            }

            return collaborateurTechnologie;
        }

        // PUT: api/CollaborateurTechnologies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollaborateurTechnologie(string id, CollaborateurTechnologie collaborateurTechnologie)
        {
            if (id != collaborateurTechnologie.Id_Collaborateur)
            {
                return BadRequest();
            }

            _context.Entry(collaborateurTechnologie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollaborateurTechnologieExists(id))
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

        // POST: api/CollaborateurTechnologies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollaborateurTechnologie>> PostCollaborateurTechnologie(CollaborateurTechnologie collaborateurTechnologie)
        {
            _context.CollaborateurTechnologie.Add(collaborateurTechnologie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CollaborateurTechnologieExists(collaborateurTechnologie.Id_Collaborateur))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCollaborateurTechnologie", new { id = collaborateurTechnologie.Id_Collaborateur }, collaborateurTechnologie);
        }

        // DELETE: api/CollaborateurTechnologies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaborateurTechnologie(string id)
        {
            var collaborateurTechnologie = await _context.CollaborateurTechnologie.FindAsync(id);
            if (collaborateurTechnologie == null)
            {
                return NotFound();
            }

            _context.CollaborateurTechnologie.Remove(collaborateurTechnologie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollaborateurTechnologieExists(string id)
        {
            return _context.CollaborateurTechnologie.Any(e => e.Id_Collaborateur == id);
        }
    }
}
