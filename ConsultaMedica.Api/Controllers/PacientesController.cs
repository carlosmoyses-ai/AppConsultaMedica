using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly ApiDbContext _context;
        
        public PacientesController(ApiDbContext context) => _context = context;

        // GET: Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteModel>>> GetPacientes()
            => await _context.Paciente!.ToListAsync();

        // GET: Pacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteModel>> GetPacienteModel(int id)
        {
            var pacienteModel = await _context.Paciente!.FindAsync(id);

            return (pacienteModel == null) ? NotFound() : pacienteModel;
        }

        // PUT: Pacientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacienteModel(int id, PacienteModel pacienteModel)
        {
            if (id != pacienteModel.PacienteId)
                return BadRequest();

            _context.Entry(pacienteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteModelExists(id))
                    return NotFound();
                else
                    throw new Exception("Erro ao atualizar o paciente");
            }

            return NoContent();
        }

        // POST: Pacientes
        [HttpPost]
        public async Task<ActionResult<PacienteModel>> PostPacienteModel(PacienteModel pacienteModel)
        {
            _context.Paciente!.Add(pacienteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacienteModel", new { id = pacienteModel.PacienteId }, pacienteModel);
        }

        // DELETE: Pacientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PacienteModel>> DeletePacienteModel(int id)
        {
            var pacienteModel = await _context.Paciente!.FindAsync(id);
            if (pacienteModel == null)
                return NotFound();

            _context.Paciente!.Remove(pacienteModel);
            await _context.SaveChangesAsync();

            return pacienteModel;
        }

        private bool PacienteModelExists(int id)
            => throw new NotImplementedException();
    }
}