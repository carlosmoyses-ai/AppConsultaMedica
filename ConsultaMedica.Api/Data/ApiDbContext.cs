using ConsultaMedica.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaMedica.Api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {}
    
    public DbSet<MedicoModel>? Medico { get; set; }
    public DbSet<PacienteModel>? Paciente { get; set; }
    public DbSet<RecepcionistaModel>? Recepcionista { get; set; }
    public DbSet<ConsultaModel>? Consulta { get; set; }
    public DbSet<EspecialidadeModel>? Especialidade { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DataBase/Consultorio.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicoModel>()
            .HasKey(m => m.MedicoId);
        
        modelBuilder.Entity<MedicoModel>()
            .Property(m => m.MedicoId)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<EspecialidadeModel>()
            .HasKey(e => e.EspecialidadeId);
        
        modelBuilder.Entity<EspecialidadeModel>()
            .Property(e => e.EspecialidadeId)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<PacienteModel>()
            .HasKey(p => p.PacienteId);

        modelBuilder.Entity<PacienteModel>()
            .Property(p => p.PacienteId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<RecepcionistaModel>()
            .HasKey(r => r.RecepcionistaId);

        modelBuilder.Entity<RecepcionistaModel>()
            .Property(r => r.RecepcionistaId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ConsultaModel>()
            .HasKey(c => c.ConsultaId);

        modelBuilder.Entity<ConsultaModel>()
            .Property(c => c.ConsultaId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<ConsultaModel>()
            .HasOne(c => c.Medico)
            .WithMany(m => m.Consultas)
            .HasForeignKey("MedicoId");
        
        modelBuilder.Entity<ConsultaModel>()
            .HasOne(c => c.Paciente)
            .WithMany(p => p.Consultas)
            .HasForeignKey("PacienteId");
        
        modelBuilder.Entity<MedicoModel>()
            .HasMany(m => m.Consultas)
            .WithOne(c => c.Medico)
            .HasForeignKey("MedicoId");

        modelBuilder.Entity<MedicoModel>()
            .HasMany(m => m.Especialidades)
            .WithMany(e => e.Medicos)
            .UsingEntity<Dictionary<string, object>>(
                "MedicoEspecialidade",
                m => m
                    .HasOne<EspecialidadeModel>()
                    .WithMany()
                    .HasForeignKey("EspecialidadeId"),
                e => e
                    .HasOne<MedicoModel>()
                    .WithMany()
                    .HasForeignKey("MedicoId"),
                me =>
                {
                    me.HasKey("MedicoId", "EspecialidadeId");
                });

        modelBuilder.Entity<PacienteModel>()
            .HasMany(p => p.Consultas)
            .WithOne(c => c.Paciente)
            .HasForeignKey("PacienteId");
        
        modelBuilder.Entity<RecepcionistaModel>()
            .HasMany(r => r.Consultas)
            .WithOne(c => c.Recepcionista)
            .HasForeignKey("RecepcionistaId");

    }

}
