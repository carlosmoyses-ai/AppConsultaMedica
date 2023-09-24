using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models;

[Table("Consulta")]
public class ConsultaModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ConsultaId { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    [Column(TypeName = "Data Consulta")]
    public DateTime DataConsulta { get; set; }

    [Required]
    [StringLength(50)]
    [Column(TypeName = "Tipo Consulta")]
    public string? TipoConsulta { get; set; }

    [Required]
    [StringLength(500)]
    [Column(TypeName = "Observacoes")]
    public string? Observacoes { get; set; }

    [Required]
    [Column(TypeName = "Paciente")]
    public PacienteModel? Paciente { get; set; }

    [Required]
    [Column(TypeName = "Medico")]
    public MedicoModel? Medico { get; set; }

    [Required]
    [Column(TypeName = "Recepcionista")]
    public RecepcionistaModel? Recepcionista { get; set; }
}