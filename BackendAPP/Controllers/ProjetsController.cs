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
    public class ProjetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Projets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projet>>> GetProjet()
        {
            return await _context.Projet.ToListAsync();
        }

        // GET: api/Projets/5
        [HttpGet("{id:int}")]
        
        public async Task<ActionResult<Projet>> GetProjet(long id)
        {
            var projet = await _context.Projet.FindAsync(id);

            if (projet == null)
            {
                return NotFound();
            }

            return projet;
        }

        // GET: api/Projets/5/1
        [HttpGet("{idProjet:int}/{idClient:int}")]

        public async Task<ActionResult<Projet>> GetInfoProjet(long idProjet, int idClient)
        {
            var projet = await _context.Projet.FindAsync(idProjet, idClient);
             

            if (projet == null)
            {
                return NotFound();
            }
            
            return projet;

        }

        // GET: api/projets/Client-2
        [HttpGet("Client_{idClient:int}")]
        public async Task<IEnumerable<Projet>> GetProjetOfClient( int idClient)
        {

            var projet = await _context.Projet
                .Where(p => p.Id_Client == idClient)
                .ToListAsync();

            return projet;
        }

        // GET: api/projets/maritime
        [HttpGet("{domaine}")]
        public async Task<IEnumerable<Projet>> GetProjetByDomaine(string domaine)
        {
            
            var projet = await _context.Projet
                .Where(p => p.Domaine == domaine)
                .ToListAsync();

            return projet;
        }

        // GET: api/projets/ETCS
        [HttpGet("_{libelle}")]
        public async Task<IEnumerable<Projet>> GetProjetByName(string libelle)
        {
            var projet = await _context.Projet
                .Where(p => p.Libelle == libelle)
                .ToListAsync();

            return projet;
        }

        // PUT: api/Projets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjet(long id, Projet projet)
        {
            if (id != projet.Id_Projet)
            {
                return BadRequest();
            }

            _context.Entry(projet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetExists(id))
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

        // POST: api/Projets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Projet>> PostProjet(Projet projet)
        {
            _context.Projet.Add(projet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjetExists(projet.Id_Projet))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjet", new { id = projet.Id_Projet }, projet);
        }

        // DELETE: api/Projets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjet(long id)
        {
            var projet = await _context.Projet.FindAsync(id);
            if (projet == null)
            {
                return NotFound();
            }

            _context.Projet.Remove(projet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetExists(long id)
        {
            return _context.Projet.Any(e => e.Id_Projet == id);
        }
    }
}
