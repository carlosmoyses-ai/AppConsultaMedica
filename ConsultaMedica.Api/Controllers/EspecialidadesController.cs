using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EspecialidadesController(ApiDbContext context) => _context = context;

        // GET: Especialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadeModel>>> GetEspecialidades()
            => await _context.Especialidade!.ToListAsync();
        
        // GET: Especialidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialidadeModel>> GetEspecialidadeModel(int id)
        {
            var especialidadeModel = await _context.Especialidade!.FindAsync(id);

            return (especialidadeModel == null) ? NotFound() : especialidadeModel;
        }

        // PUT: Especialidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidadeModel(int id, EspecialidadeModel especialidadeModel)
        {
            if (id != especialidadeModel.EspecialidadeId)
                return BadRequest();

            _context.Entry(especialidadeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadeModelExists(id))
                    return NotFound();
                else
                    throw new Exception("Erro ao atualizar a especialidade");
            }

            return NoContent();
        }

        // POST: Especialidades
        [HttpPost]
        public async Task<ActionResult<EspecialidadeModel>> PostEspecialidadeModel(EspecialidadeModel especialidadeModel)
        {
            _context.Especialidade!.Add(especialidadeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecialidadeModel", new { id = especialidadeModel.EspecialidadeId }, especialidadeModel);
        }

        // DELETE: Especialidades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EspecialidadeModel>> DeleteEspecialidadeModel(int id)
        {
            var especialidadeModel = await _context.Especialidade!.FindAsync(id);
            if (especialidadeModel == null)
                return NotFound();

            _context.Especialidade!.Remove(especialidadeModel);
            await _context.SaveChangesAsync();

            return especialidadeModel;
        }

        private bool EspecialidadeModelExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}