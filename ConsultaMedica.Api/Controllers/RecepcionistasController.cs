using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecepcionistasController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public RecepcionistasController(ApiDbContext context) => _context = context;

        // GET: Recepcionistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecepcionistaModel>>> GetRecepcionistas()
            => await _context.Recepcionista!.ToListAsync();

        // GET: Recepcionistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecepcionistaModel>> GetRecepcionistaModel(int id)
        {
            var recepcionistaModel = await _context.Recepcionista!.FindAsync(id);

            return (recepcionistaModel == null) ? NotFound() : recepcionistaModel;
        }

        // PUT: Recepcionistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepcionistaModel(int id, RecepcionistaModel recepcionistaModel)
        {
            if (id != recepcionistaModel.RecepcionistaId)
                return BadRequest();

            _context.Entry(recepcionistaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepcionistaModelExists(id))
                    return NotFound();
                else
                    throw new Exception("Erro ao atualizar a recepcionista");
            }

            return NoContent();
        }

        // POST: Recepcionistas
        [HttpPost]
        public async Task<ActionResult<RecepcionistaModel>> PostRecepcionistaModel(RecepcionistaModel recepcionistaModel)
        {
            _context.Recepcionista!.Add(recepcionistaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecepcionistaModel", new { id = recepcionistaModel.RecepcionistaId }, recepcionistaModel);
        }

        // DELETE: Recepcionistas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecepcionistaModel>> DeleteRecepcionistaModel(int id)
        {
            var recepcionistaModel = await _context.Recepcionista!.FindAsync(id);
            if (recepcionistaModel == null)
                return NotFound();

            _context.Recepcionista!.Remove(recepcionistaModel);
            await _context.SaveChangesAsync();

            return recepcionistaModel;
        }

        private bool RecepcionistaModelExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}