using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorarioAtendimentoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public HorarioAtendimentoController(ApiDbContext context) => _context = context;

        // GET: HorarioAtendimento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorarioAtendimentoModel>>> GetHorarioAtendimentos()
            => await _context.HorarioAtendimento!.ToListAsync();

        // GET: HorarioAtendimento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorarioAtendimentoModel>> GetHorarioAtendimentoModel(int id)
        {
            var horarioAtendimentoModel = await _context.HorarioAtendimento!.FindAsync(id);

            return (horarioAtendimentoModel == null) ? NotFound() : horarioAtendimentoModel;
        }

        // PUT: HorarioAtendimento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorarioAtendimentoModel(int id, HorarioAtendimentoModel horarioAtendimentoModel)
        {
            if (id != horarioAtendimentoModel.HorarioAtendimentoId)
                return BadRequest();

            _context.Entry(horarioAtendimentoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioAtendimentoModelExists(id))
                    return NotFound();
                else
                    throw new Exception("Erro ao atualizar o horário de atendimento");
            }

            return NoContent();
        }

        // POST: HorarioAtendimento
        [HttpPost]
        public async Task<ActionResult<HorarioAtendimentoModel>> PostHorarioAtendimentoModel(HorarioAtendimentoModel horarioAtendimentoModel)
        {
            _context.HorarioAtendimento!.Add(horarioAtendimentoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorarioAtendimentoModel", new { id = horarioAtendimentoModel.HorarioAtendimentoId }, horarioAtendimentoModel);
        }

        // DELETE: HorarioAtendimento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HorarioAtendimentoModel>> DeleteHorarioAtendimentoModel(int id)
        {
            var horarioAtendimentoModel = await _context.HorarioAtendimento!.FindAsync(id);
            if (horarioAtendimentoModel == null)
                return NotFound();

            _context.HorarioAtendimento!.Remove(horarioAtendimentoModel);
            await _context.SaveChangesAsync();

            return horarioAtendimentoModel;
        }

        private bool HorarioAtendimentoModelExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}