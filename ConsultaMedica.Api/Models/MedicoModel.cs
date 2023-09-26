using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaMedica.Api.Models;

public class MedicoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MedicoId { get; set; }
    public string? MedicoNome { get; set; }
    public string? NumeroRegistroProfissional { get; set; }
    public int EspecialidadeId { get; set; }

    // Relacionamento com Especialidade
    public List<EspecialidadeModel>? Especialidades { get; set; }

    // Lista de Consultas agendadas com este médico
    public List<ConsultaModel>? Consultas { get; set; }

    // Lista de Horários Disponíveis deste médico
    public List<HorarioAtendimentoModel>? HorariosAtendimento { get; set; }
}