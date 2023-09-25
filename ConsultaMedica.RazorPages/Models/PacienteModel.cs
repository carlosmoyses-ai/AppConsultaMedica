using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    [Table("Paciente")]
    public class PacienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PacienteId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Nome")]
        public string? PacienteNome { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Sobrenome")]
        public string? PacienteSobrenome { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Numero Identificacao")]
        public string? NumeroIdentificacao { get; set; }
        
        [Required]
        [StringLength(50)]
        [Column(TypeName = "Historico Clinico")]
        public string? HistoricoClinico { get; set; }

        [Required]
        [Column(TypeName = "Consultas")]
        public IList<ConsultaModel>? Consultas { get; set; }
    }
}