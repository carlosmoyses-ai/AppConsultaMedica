using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ConsultaController : ControllerBase
{
    private readonly ApiDbContext _context;

    public ConsultaController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var consultas = await _context.Consulta!.ToListAsync();
        return Ok(consultas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var consulta = await _context.Consulta!.FirstOrDefaultAsync(p => p.ConsultaId == id);
        if (consulta == null)
        {
            return NotFound();
        }
        return Ok(consulta);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(ConsultaModel consulta)
    {
        _context.Consulta!.Add(consulta);
        await _context.SaveChangesAsync();
        return Ok(consulta);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(ConsultaModel consulta)
    {
        _context.Entry(consulta).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(consulta);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var consulta = await _context.Consulta!.FirstOrDefaultAsync(p => p.ConsultaId == id);
        if (consulta == null)
        {
            return NotFound();
        }
        _context.Consulta!.Remove(consulta);
        await _context.SaveChangesAsync();
        return Ok(consulta);
    }
}