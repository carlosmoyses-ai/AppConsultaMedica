using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.RazorPages.Models;

[Table("Medico")]
public class MedicoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MedicoId { get; set; }

    [Required]
    [StringLength(50)]
    [Column(TypeName = "Nome")]
    public string? MedicoNome { get; set; }

    [Required]
    [StringLength(50)]
    [Column(TypeName = "Numero Registro Profissional")]
    public string? NumeroRegistroProfisional { get; set; }

    [Required]
    [StringLength(50)]
    [Column(TypeName = "Horarios Atendimento")]
    public List<DateTime>? HorariosAtendimento { get; set; }

    [Required]
    [Column(TypeName = "Especialidades")]
    public IList<EspecialidadeModel>? Especialidades { get; set; }

    [Required]
    [Column(TypeName = "Consultas")]
    public IList<ConsultaModel>? Consultas { get; set; }
}