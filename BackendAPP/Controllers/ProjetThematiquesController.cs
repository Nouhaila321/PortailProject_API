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
    public class ProjetThematiquesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjetThematiquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjetThematiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetThematique>>> GetProjetThematique()
        {
            return await _context.ProjetThematique.ToListAsync();
        }

        // GET: api/ProjetThematiques/5
        [HttpGet("{idProjet}/{idClient}/{idThematique}")]
        public async Task<ActionResult<ProjetThematique>> GetProjetThematique(long idProjet, long idClient, long idThematique)
        {
            var projetThematique = await _context.ProjetThematique.FindAsync(idProjet, idClient, idThematique);

            if (projetThematique == null)
            {
                return NotFound();
            }

            return projetThematique;
        }

        // GET: api/ProjetThematique/1
        [HttpGet("{idProjet}/{idClient}")]
        public async Task<IEnumerable<ProjetThematique>> GetAllProjetThematique(long idProjet,  long idClient)
        {

            var projet = await _context.ProjetThematique
                .Where(p => p.id_projet == idProjet && p.id_client == idClient)
                .ToListAsync();

            return projet;
        }

        // PUT: api/ProjetThematiques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjetThematique(long id, ProjetThematique projetThematique)
        {
            if (id != projetThematique.id_client)
            {
                return BadRequest();
            }

            _context.Entry(projetThematique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetThematiqueExists(id))
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

        // POST: api/ProjetThematiques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjetThematique>> PostProjetThematique(ProjetThematique projetThematique)
        {
            _context.ProjetThematique.Add(projetThematique);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjetThematiqueExists(projetThematique.id_client))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjetThematique", new { id = projetThematique.id_client }, projetThematique);
        }

        // DELETE: api/ProjetThematiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjetThematique(long id)
        {
            var projetThematique = await _context.ProjetThematique.FindAsync(id);
            if (projetThematique == null)
            {
                return NotFound();
            }

            _context.ProjetThematique.Remove(projetThematique);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetThematiqueExists(long id)
        {
            return _context.ProjetThematique.Any(e => e.id_client == id);
        }
    }
}
