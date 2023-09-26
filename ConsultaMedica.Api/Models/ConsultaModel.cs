using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsultaMedica.Api.Models.Enums;

namespace ConsultaMedica.Api.Models
{
    public class ConsultaModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultaId { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public TipoConsultaEnum TipoConsulta { get; set; }
        public string? Observacoes { get; set; }

        // Relacionamento com Médico
        public MedicoModel? Medico { get; set; }

        // Relacionamento com Paciente
        public PacienteModel? Paciente { get; set; }
    }
}