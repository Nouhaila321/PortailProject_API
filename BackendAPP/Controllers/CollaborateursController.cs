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
    public class CollaborateursController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CollaborateursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Collaborateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collaborateur>>> GetCollaborateur()
        {
            return await _context.Collaborateur.ToListAsync();
        }

        // GET: api/Collaborateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collaborateur>> GetCollaborateur(string id)
        {
            var collaborateur = await _context.Collaborateur.FindAsync(id);

            if (collaborateur == null)
            {
                return NotFound();
            }

            return collaborateur;
        }
        

        // PUT: api/Collaborateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollaborateur(string id, Collaborateur collaborateur)
        {
            if (id != collaborateur.Id_Collaborateur)
            {
                return BadRequest();
            }

            _context.Entry(collaborateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollaborateurExists(id))
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

        // POST: api/Collaborateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Collaborateur>> PostCollaborateur(Collaborateur collaborateur)
        {
            _context.Collaborateur.Add(collaborateur);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CollaborateurExists(collaborateur.Id_Collaborateur))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCollaborateur", new { id = collaborateur.Id_Collaborateur }, collaborateur);
        }

        // DELETE: api/Collaborateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaborateur(string id)
        {
            var collaborateur = await _context.Collaborateur.FindAsync(id);
            if (collaborateur == null)
            {
                return NotFound();
            }

            _context.Collaborateur.Remove(collaborateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollaborateurExists(string id)
        {
            return _context.Collaborateur.Any(e => e.Id_Collaborateur == id);
        }
    }
}
