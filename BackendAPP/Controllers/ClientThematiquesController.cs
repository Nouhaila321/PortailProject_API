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
    public class ClientThematiquesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientThematiquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientThematiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientThematique>>> GetClientThematique()
        {
            return await _context.ClientThematique.ToListAsync();
        }

        
        // GET: api/ClientThematiques/1
        [HttpGet("{idClient}")]
        public async Task<IEnumerable<ClientThematique>> GetAllProjetThematique( long idClient)
        {

            var thematiques = await _context.ClientThematique
                .Where(p => p.Id_Client == idClient)
                .ToListAsync();

            return thematiques;
        }

        // PUT: api/ClientThematiques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientThematique(long id, ClientThematique clientThematique)
        {
            if (id != clientThematique.Id_Client)
            {
                return BadRequest();
            }

            _context.Entry(clientThematique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientThematiqueExists(id))
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

        // POST: api/ClientThematiques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientThematique>> PostClientThematique(ClientThematique clientThematique)
        {
            _context.ClientThematique.Add(clientThematique);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientThematiqueExists(clientThematique.Id_Client))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClientThematique", new { id = clientThematique.Id_Client }, clientThematique);
        }

        // DELETE: api/ClientThematiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientThematique(long id)
        {
            var clientThematique = await _context.ClientThematique.FindAsync(id);
            if (clientThematique == null)
            {
                return NotFound();
            }

            _context.ClientThematique.Remove(clientThematique);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientThematiqueExists(long id)
        {
            return _context.ClientThematique.Any(e => e.Id_Client == id);
        }
    }
}
