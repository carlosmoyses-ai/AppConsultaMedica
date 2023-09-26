using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    public class RecepcionistaModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecepcionistaId { get; set; }
        public string? RecepcionistaNome { get; set; }
        public string? RecepcionistaSobrenome { get; set; }
        public string? NumeroIdentificacao { get; set; }
        public string? NumeroTelefone { get; set; }

        // Lista de Consultas agendadas com este recepcionista
        public List<ConsultaModel>? Consultas { get; set; }
    }
}