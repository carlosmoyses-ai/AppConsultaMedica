using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EspecialidadeController : ControllerBase
{
    private readonly ApiDbContext _context;

    public EspecialidadeController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var especialidades = await _context.Especialidade!.ToListAsync();
        return Ok(especialidades);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var especialidade = await _context.Especialidade!.FirstOrDefaultAsync(p => p.EspecialidadeId == id);
        if (especialidade == null)
        {
            return NotFound();
        }
        return Ok(especialidade);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(EspecialidadeModel especialidade)
    {
        _context.Especialidade!.Add(especialidade);
        await _context.SaveChangesAsync();
        return Ok(especialidade);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(EspecialidadeModel especialidade)
    {
        _context.Entry(especialidade).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(especialidade);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var especialidade = await _context.Especialidade!.FirstOrDefaultAsync(p => p.EspecialidadeId == id);
        if (especialidade == null)
        {
            return NotFound();
        }
        _context.Especialidade!.Remove(especialidade);
        await _context.SaveChangesAsync();
        return Ok(especialidade);
    }
}