using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ConsultasController(ApiDbContext context) => _context = context;

        // GET: Consultas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaModel>>> GetConsultas()
            => await _context.Consulta!.ToListAsync();

        // GET: Consultas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaModel>> GetConsultaModel(int id)
        {
            var consultaModel = await _context.Consulta!.FindAsync(id);

            return (consultaModel == null) ? NotFound() : consultaModel;
        }

        // PUT: Consultas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultaModel(int id, ConsultaModel consultaModel)
        {
            if (id != consultaModel.ConsultaId)
                return BadRequest();

            _context.Entry(consultaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaModelExists(id))
                    return NotFound();
                else
                    throw new Exception("Erro ao atualizar a consulta");
            }

            return NoContent();
        }

        // POST: Consultas
        [HttpPost]
        public async Task<ActionResult<ConsultaModel>> PostConsultaModel(ConsultaModel consultaModel)
        {
            _context.Consulta!.Add(consultaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultaModel", new { id = consultaModel.ConsultaId }, consultaModel);
        }

        // DELETE: Consultas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsultaModel>> DeleteConsultaModel(int id)
        {
            var consultaModel = await _context.Consulta!.FindAsync(id);
            if (consultaModel == null)
                return NotFound();

            _context.Consulta!.Remove(consultaModel);
            await _context.SaveChangesAsync();

            return consultaModel;
        }

        private bool ConsultaModelExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}