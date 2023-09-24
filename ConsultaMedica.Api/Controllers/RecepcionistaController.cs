using ConsultaMedica.Api.Data;
using ConsultaMedica.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecepcionistaController : ControllerBase {
    private readonly ApiDbContext _context;

    public RecepcionistaController(ApiDbContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync() {
        var recepcionistas = await _context.Recepcionista!.ToListAsync();
        return Ok(recepcionistas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id) {
        var recepcionista = await _context.Recepcionista!.FirstOrDefaultAsync(r => r.RecepcionistaId == id);
        if (recepcionista == null) {
            return NotFound();
        }
        return Ok(recepcionista);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(RecepcionistaModel recepcionista) {
        _context.Recepcionista!.Add(recepcionista);
        await _context.SaveChangesAsync();
        return Ok(recepcionista);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(RecepcionistaModel recepcionista) {
        _context.Entry(recepcionista).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(recepcionista);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id) {
        var recepcionista = await _context.Recepcionista!.FirstOrDefaultAsync(r => r.RecepcionistaId == id);
        if (recepcionista == null) {
            return NotFound();
        }
        _context.Recepcionista!.Remove(recepcionista);
        await _context.SaveChangesAsync();
        return Ok(recepcionista);
    }
}