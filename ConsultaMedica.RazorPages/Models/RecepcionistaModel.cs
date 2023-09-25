using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    [Table("Recepcionista")]
    public class RecepcionistaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecepcionistaId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Nome")]
        public string? RecepcionistaNome { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Sobrenome")]
        public string? RecepcionistaSobrenome { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Numero Identificacao")]
        public string? NumeroIdentificacao { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Numero Telefone")]
        public string? NumeroTelefone { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "Consulta")]
        public IList<ConsultaModel>? Consultas { get; set; }
    }
}