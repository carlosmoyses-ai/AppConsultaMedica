using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController : ControllerBase
{
    private readonly ApiDbContext _context;

    public PacienteController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var pacientes = await _context.Paciente!.ToListAsync();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var paciente = await _context.Paciente!.FirstOrDefaultAsync(p => p.PacienteId == id);
        if (paciente == null)
        {
            return NotFound();
        }
        return Ok(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(PacienteModel paciente)
    {
        _context.Paciente!.Add(paciente);
        await _context.SaveChangesAsync();
        return Ok(paciente);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(PacienteModel paciente)
    {
        _context.Entry(paciente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(paciente);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var paciente = await _context.Paciente!.FirstOrDefaultAsync(p => p.PacienteId == id);
        if (paciente == null)
        {
            return NotFound();
        }
        _context.Paciente!.Remove(paciente);
        await _context.SaveChangesAsync();
        return Ok(paciente);
    }
}