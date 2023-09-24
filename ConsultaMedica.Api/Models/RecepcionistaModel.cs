using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    [Table("Recepcionista")]
    public class RecepcionistaModel
    {
        public int RecepcionistaId { get; set; }
        public string? RecepcionistaNome { get; set; }
        public string? RecepcionistaSobrenome { get; set; }
        public string? NumeroIdentificacao { get; set; }
        public string? NumeroTelefone { get; set; }
    }
}