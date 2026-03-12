using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shadow_Eventos.Domains;

namespace Shadow_Eventos.Contexts;

public partial class Shadow_EventosContext : DbContext
{
    public Shadow_EventosContext()
    {
    }

    public Shadow_EventosContext(DbContextOptions<Shadow_EventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evento> Evento { get; set; }

    public virtual DbSet<Inscricao> Inscricao { get; set; }

    public virtual DbSet<Palestrante> Palestrante { get; set; }

    public virtual DbSet<Participante> Participante { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=D06S31-1313863\\SQLEXPRRESS;Database=Shadow_Eventos;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoID).HasName("PK__Evento__1EEB5901C9378CE8");

            entity.Property(e => e.DataEvento).HasPrecision(0);
            entity.Property(e => e.LocalEvento).HasMaxLength(150);
            entity.Property(e => e.Nome).HasMaxLength(75);

            entity.HasOne(d => d.Palestrante).WithMany(p => p.Evento)
                .HasForeignKey(d => d.PalestranteID)
                .HasConstraintName("FK__Evento__Palestra__4CA06362");
        });

        modelBuilder.Entity<Inscricao>(entity =>
        {
            entity.HasKey(e => e.InscricaoID).HasName("PK__Inscrica__CD089C4E67DD8542");

            entity.HasIndex(e => new { e.EventoID, e.ParticipanteID }, "Inscricao_Evento_Participante").IsUnique();

            entity.HasOne(d => d.Evento).WithMany(p => p.Inscricao)
                .HasForeignKey(d => d.EventoID)
                .HasConstraintName("FK__Inscricao__Event__534D60F1");

            entity.HasOne(d => d.Participante).WithMany(p => p.Inscricao)
                .HasForeignKey(d => d.ParticipanteID)
                .HasConstraintName("FK__Inscricao__Parti__5441852A");
        });

        modelBuilder.Entity<Palestrante>(entity =>
        {
            entity.HasKey(e => e.PalestranteID).HasName("PK__Palestra__404E96B669623EDF");

            entity.Property(e => e.AreaAtuacao).HasMaxLength(50);
            entity.Property(e => e.Nome).HasMaxLength(75);
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.ParticipanteID).HasName("PK__Particip__E6DEAC3F8BE0FE86");

            entity.HasIndex(e => e.Email, "UQ__Particip__A9D105349CF5CC98").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(125);
            entity.Property(e => e.Nome).HasMaxLength(75);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
