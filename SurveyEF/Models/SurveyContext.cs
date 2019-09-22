using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SurveyEF.Models
{
    internal partial class SurveyContext : DbContext
    {
        public SurveyContext()
        {
        }

        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alternativa> Alternativa { get; set; }
        public virtual DbSet<Pergunta> Pergunta { get; set; }
        public virtual DbSet<PerguntaTag> PerguntaTag { get; set; }
        public virtual DbSet<Questionario> Questionario { get; set; }
        public virtual DbSet<Resposta> Resposta { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TipoPergunta> TipoPergunta { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=den1.mssql3.gear.host;Initial Catalog=surveyprof;Persist Security Info=True;User ID=surveyprof;Password=Cb1Wnx~Jr0a!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alternativa>(entity =>
            {
                entity.Property(e => e.Opcao)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pergunta)
                    .WithMany(p => p.Alternativa)
                    .HasForeignKey(d => d.PerguntaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alternativa_Pergunta");
            });

            modelBuilder.Entity<Pergunta>(entity =>
            {
                entity.Property(e => e.Descricao).HasColumnType("text");

                entity.Property(e => e.Dica)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Obrigatoria)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Ordem).HasColumnType("numeric(3, 1)");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Questionario)
                    .WithMany(p => p.Pergunta)
                    .HasForeignKey(d => d.QuestionarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pergunta_Questionario");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Pergunta)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pergunta_TipoPergunta");
            });

            modelBuilder.Entity<PerguntaTag>(entity =>
            {
                entity.HasKey(e => new { e.IdPergunta, e.IdTag });

                entity.HasOne(d => d.IdPerguntaNavigation)
                    .WithMany(p => p.PerguntaTag)
                    .HasForeignKey(d => d.IdPergunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerguntaTag_Pergunta1");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.PerguntaTag)
                    .HasForeignKey(d => d.IdTag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerguntaTag_Tag1");
            });

            modelBuilder.Entity<Questionario>(entity =>
            {
                entity.Property(e => e.Fim).HasColumnType("datetime");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem64).IsUnicode(false);

                entity.Property(e => e.Inicio).HasColumnType("datetime");

                entity.Property(e => e.MsgFeedback).HasColumnType("text");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Questionario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questionario_Usuario");
            });

            modelBuilder.Entity<Resposta>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Numerica).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Texto).HasColumnType("text");

                entity.Property(e => e.TextoCurto)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Alternativa)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.AlternativaId)
                    .HasConstraintName("FK_Resposta_Alternativa");

                entity.HasOne(d => d.Pergunta)
                    .WithMany(p => p.Resposta)
                    .HasForeignKey(d => d.PerguntaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resposta_Pergunta");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPergunta>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("IX_Usuario")
                    .IsUnique();

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.DataFim).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });
        }
    }
}
