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
    public class ProjetGaleriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjetGaleriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjetGaleries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjetGalerie>>> GetProjetGalerie()
        {
            return await _context.ProjetGalerie.ToListAsync();
        }

        // GET: api/ProjetGaleries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetGalerie>> GetProjetGalerie(long id)
        {
            var projetGalerie = await _context.ProjetGalerie.FindAsync(id);

            if (projetGalerie == null)
            {
                return NotFound();
            }

            return projetGalerie;
        }

        // PUT: api/ProjetGaleries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjetGalerie(long id, ProjetGalerie projetGalerie)
        {
            if (id != projetGalerie.id_client)
            {
                return BadRequest();
            }

            _context.Entry(projetGalerie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjetGalerieExists(id))
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

        // POST: api/ProjetGaleries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjetGalerie>> PostProjetGalerie(ProjetGalerie projetGalerie)
        {
            _context.ProjetGalerie.Add(projetGalerie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProjetGalerieExists(projetGalerie.id_client))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProjetGalerie", new { id = projetGalerie.id_client }, projetGalerie);
        }

        // DELETE: api/ProjetGaleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjetGalerie(long id)
        {
            var projetGalerie = await _context.ProjetGalerie.FindAsync(id);
            if (projetGalerie == null)
            {
                return NotFound();
            }

            _context.ProjetGalerie.Remove(projetGalerie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjetGalerieExists(long id)
        {
            return _context.ProjetGalerie.Any(e => e.id_client == id);
        }
    }
}
