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
    public class CollaborateurActivitesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CollaborateurActivitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CollaborateurActivites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollaborateurActivite>>> GetCollaborateurActivite()
        {
            return await _context.CollaborateurActivite.ToListAsync();
        }

        // GET: api/CollaborateurActivites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollaborateurActivite>> GetCollaborateurActivite(string id)
        {
            var collaborateurActivite = await _context.CollaborateurActivite.FindAsync(id);

            if (collaborateurActivite == null)
            {
                return NotFound();
            }

            return collaborateurActivite;
        }

        //GET: api/CollaborateurActivites/projet/76
        [HttpGet("projet/{idProjet}")]
        public async Task<ActionResult<IEnumerable<Collaborateur>>> GetCollaborateurProjet(string idProjet)
        {
            var collaborateurActivite = await _context.CollaborateurActivite
               .Where(p => p.Id_Projet == idProjet )
               .ToListAsync();

            List<Collaborateur> collaborateurs = new List<Collaborateur>();


            foreach (CollaborateurActivite element in collaborateurActivite)
            {

                var collaborateur = await _context.Collaborateur.FindAsync(element.Id_Collaborateur);
                collaborateurs.Add(collaborateur);
            }

            return collaborateurs;
        }

        // PUT: api/CollaborateurActivites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollaborateurActivite(string id, CollaborateurActivite collaborateurActivite)
        {
            if (id != collaborateurActivite.Id_Projet)
            {
                return BadRequest();
            }

            _context.Entry(collaborateurActivite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollaborateurActiviteExists(id))
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

        // POST: api/CollaborateurActivites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollaborateurActivite>> PostCollaborateurActivite(CollaborateurActivite collaborateurActivite)
        {
            _context.CollaborateurActivite.Add(collaborateurActivite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CollaborateurActiviteExists(collaborateurActivite.Id_Projet))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCollaborateurActivite", new { id = collaborateurActivite.Id_Projet }, collaborateurActivite);
        }

        // DELETE: api/CollaborateurActivites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaborateurActivite(string id)
        {
            var collaborateurActivite = await _context.CollaborateurActivite.FindAsync(id);
            if (collaborateurActivite == null)
            {
                return NotFound();
            }

            _context.CollaborateurActivite.Remove(collaborateurActivite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollaborateurActiviteExists(string id)
        {
            return _context.CollaborateurActivite.Any(e => e.Id_Projet == id);
        }
    }
}
