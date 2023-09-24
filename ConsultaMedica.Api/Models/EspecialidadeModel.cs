using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    [Table("Especialidade")]
    public class EspecialidadeModel
    {
        public int EspecialidadeId { get; set; }
        public string? EspecialidadeNome { get; set; }
        public string? DescricaoEspecialidade { get; set; }
        public IList<MedicoModel>? Medicos { get; set; }
    }
}