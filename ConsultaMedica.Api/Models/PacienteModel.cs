using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    public class PacienteModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacienteId { get; set; }
        public string? PacienteNome { get; set; }
        public string? NumeroIdentificacao { get; set; }
        public string? HistoricoMedico { get; set; }
        
        // Lista de Consultas agendadas com este paciente
        public List<ConsultaModel>? Consultas { get; set; }
    }
}