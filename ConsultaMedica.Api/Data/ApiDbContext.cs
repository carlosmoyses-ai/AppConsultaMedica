using ConsultaMedica.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    public DbSet<MedicoModel>? Medico { get; set; }
    public DbSet<PacienteModel>? Paciente { get; set; }
    public DbSet<RecepcionistaModel>? Recepcionista { get; set; }
    public DbSet<ConsultaModel>? Consulta { get; set; }
    public DbSet<EspecialidadeModel>? Especialidade { get; set; }
    public DbSet<HorarioAtendimentoModel>? HorarioAtendimento { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DataBase/Consultorio.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações de tabelas e relacionamentos

        // Mapeamento da Entidade MedicoModel
        modelBuilder.Entity<MedicoModel>(entity =>
        {
            entity.HasKey(e => e.MedicoId);
            entity.Property(e => e.MedicoNome).IsRequired();
            entity.Property(e => e.NumeroRegistroProfissional).IsRequired();

            // Relacionamento N:M com Especialidades
            entity.HasMany(e => e.Especialidades)
                .WithMany(e => e.Medicos)
                .UsingEntity<Dictionary<string, object>>(
                    "MedicoEspecialidade",
                    e => e.HasOne<EspecialidadeModel>()
                        .WithMany()
                        .HasForeignKey("EspecialidadeId"),
                    e => e.HasOne<MedicoModel>()
                        .WithMany()
                        .HasForeignKey("MedicoId")
                );

            // Relacionamento 1:N com Consulta
            entity.HasMany(e => e.Consultas)
                .WithOne(e => e.Medico)
                .HasForeignKey(e => e.MedicoId)
                .IsRequired();
        });

        // Mapeamento da Entidade PacienteModel
        modelBuilder.Entity<PacienteModel>(entity =>
        {
            entity.HasKey(e => e.PacienteId);
            entity.Property(e => e.PacienteNome).IsRequired();
            entity.Property(e => e.NumeroIdentificacao).IsRequired();

            // Relacionamento 1:N com Consulta
            entity.HasMany(e => e.Consultas)
                .WithOne(e => e.Paciente)
                .HasForeignKey(e => e.PacienteId)
                .IsRequired();
        });

        // Mapeamento da Entidade RecepcionistaModel
        modelBuilder.Entity<RecepcionistaModel>(entity =>
        {
            entity.HasKey(e => e.RecepcionistaId);
            entity.Property(e => e.RecepcionistaNome).IsRequired();
            entity.Property(e => e.NumeroIdentificacao).IsRequired();
        });

        // Mapeamento da Entidade ConsultaModel
        modelBuilder.Entity<ConsultaModel>(entity =>
        {
            entity.HasKey(e => e.ConsultaId);
            entity.Property(e => e.DataHoraInicio).IsRequired();
            entity.Property(e => e.DataHoraFim).IsRequired();

            // Relacionamento 1:N com Paciente
            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Consultas)
                .HasForeignKey(e => e.PacienteId)
                .IsRequired();

            // Relacionamento 1:N com Médico
            entity.HasOne(e => e.Medico)
                .WithMany(e => e.Consultas)
                .HasForeignKey(e => e.MedicoId)
                .IsRequired();
        });

        // Mapeamento da Entidade HorarioAtendimentoModel
        modelBuilder.Entity<HorarioAtendimentoModel>(entity =>
        {
            entity.HasKey(e => e.HorarioAtendimentoId);
            entity.Property(e => e.HoraInicio).IsRequired();
            entity.Property(e => e.HoraFim).IsRequired();

            // Relacionamento 1:N com Médico
            entity.HasOne(e => e.Medico)
                .WithMany(e => e.HorariosAtendimento)
                .HasForeignKey(e => e.MedicoId)
                .IsRequired();
        });
    }
}

