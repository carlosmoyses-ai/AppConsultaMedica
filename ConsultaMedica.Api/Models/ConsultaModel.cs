using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models;

[Table("Consulta")]
public class ConsultaModel
{
    public int ConsultaId { get; set; }
    public DateTime DataConsulta { get; set; }
    public string? TipoConsulta { get; set; }
    public string? Observacoes { get; set; }
    public PacienteModel? Paciente { get; set; }
    public MedicoModel? Medico { get; set; }
}