using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models;

[Table("Medico")]
public class MedicoModel
{
    public int MedicoId { get; set; }
    public string? MedicoNome { get; set; }
    public string? NumeroRegistroProfisional { get; set; }
    public List<DateTime>? HorariosAtendimento { get; set; }
    public IList<EspecialidadeModel>? Especialidades { get; set; }
    public IList<ConsultaModel>? Consultas { get; set; }
}