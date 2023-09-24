using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    [Table("Especialidade")]
    public class EspecialidadeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EspecialidadeId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Especialidade")]
        public string? EspecialidadeNome { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "Descricao Especialidade")]
        public string? DescricaoEspecialidade { get; set; }

        [Required]
        [Column(TypeName = "Medicos")]
        public IList<MedicoModel>? Medicos { get; set; }
    }
}