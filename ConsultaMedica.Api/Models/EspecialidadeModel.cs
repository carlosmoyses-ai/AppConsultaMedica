using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    public class EspecialidadeModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EspecialidadeId { get; set; }
        public string? EspecialidadeNome { get; set; }
        public string? EspecialidadeDescricao { get; set; }

        // Lista de Médicos que possuem esta especialidade
        public List<MedicoModel>? Medicos { get; set; }
    }
}