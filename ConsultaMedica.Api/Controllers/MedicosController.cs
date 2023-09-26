using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConsultaMedica.Api.Models;
using ConsultaMedica.Api.Data;

namespace ConsultaMedica.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicosController : ControllerBase
{
    private readonly ApiDbContext _context;

    public MedicosController(ApiDbContext context) => _context = context;

    // GET: Medicos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicoModel>>> GetMedicos()
        => await _context.Medico!.ToListAsync();

    // GET: Medicos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MedicoModel>> GetMedicoModel(int id)
    {
        var medicoModel = await _context.Medico!.FindAsync(id);

        return (medicoModel == null) ? NotFound() :medicoModel;
    }

    // PUT: Medicos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMedicoModel(int id, MedicoModel medicoModel)
    {
        if (id != medicoModel.MedicoId)
            return BadRequest();

        _context.Entry(medicoModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MedicoModelExists(id))
                return NotFound();
            else
                throw new Exception("Erro ao atualizar o médico");
        }

        return NoContent();
    }

    // POST: Medicos
    [HttpPost]
    public async Task<ActionResult<MedicoModel>> PostMedicoModel(MedicoModel medicoModel)
    {
        _context.Medico!.Add(medicoModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMedicoModel", new { id = medicoModel.MedicoId }, medicoModel);
    }

    // DELETE: Medicos/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<MedicoModel>> DeleteMedicoModel(int id)
    {
        var medicoModel = await _context.Medico!.FindAsync(id);
        if (medicoModel == null)
            return NotFound();

        _context.Medico!.Remove(medicoModel);
        await _context.SaveChangesAsync();

        return medicoModel;
    }

    private bool MedicoModelExists(int id)
        => _context.Medico!.Any(e => e.MedicoId == id);
}