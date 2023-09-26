using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConsultaMedica.Api.Models.Enums;

namespace ConsultaMedica.Api.Models;
public class HorarioAtendimentoModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HorarioAtendimentoId { get; set; }
    public DiaSemanaEnum DiaSemana { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFim { get; set; }
    public int MedicoId { get; set; }
    public MedicoModel Medico { get; set; } = new();
}