using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models
{
    public class AgendamentoModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgendamentoId { get; set; }
        public int RecepcionistaId { get; set; }
        public int ConsultaId { get; set; }
        // Relacionamento com Recepcionista
        public RecepcionistaModel? Recepcionista { get; set; }

        // Relacionamento com Consulta
        public ConsultaModel? Consulta { get; set; }
    }
}