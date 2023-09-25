using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicoController : ControllerBase
{
    private readonly ApiDbContext _context;

    public MedicoController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var medicos = await _context.Medico!.ToListAsync();
        return Ok(medicos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var medico = await _context.Medico!.FirstOrDefaultAsync(p => p.MedicoId == id);
        if (medico == null)
        {
            return NotFound();
        }
        return Ok(medico);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(MedicoModel medico)
    {
        _context.Medico!.Add(medico);
        await _context.SaveChangesAsync();
        return Ok(medico);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(MedicoModel medico)
    {
        _context.Entry(medico).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(medico);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var medico = await _context.Medico!.FirstOrDefaultAsync(p => p.MedicoId == id);
        if (medico == null)
        {
            return NotFound();
        }
        _context.Medico!.Remove(medico);
        await _context.SaveChangesAsync();
        return Ok(medico);
    }
}