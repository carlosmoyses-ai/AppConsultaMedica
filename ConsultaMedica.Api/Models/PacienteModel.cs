using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    [Table("Paciente")]
    public class PacienteModel
    {
        public int PacienteId { get; set; }
        public string? PacienteNome { get; set; }
        public string? PacienteSobrenome { get; set; }
        public string? NumeroIdentificacao { get; set; }
        public string? HistoricoClinico { get; set; }
        public IList<ConsultaModel>? Consultas { get; set; }
    }
}