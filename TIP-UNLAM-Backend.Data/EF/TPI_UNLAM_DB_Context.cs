using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TPI_UNLAM_Backend.Utils;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class TPI_UNLAM_DB_Context : DbContext
    {
        public TPI_UNLAM_DB_Context()
        {
        }

        public TPI_UNLAM_DB_Context(DbContextOptions<TPI_UNLAM_DB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Colore> Colores { get; set; }
        public virtual DbSet<Juego> Juegos { get; set; }
        public virtual DbSet<Nota> Notas { get; set; }
        public virtual DbSet<ProgresosXusuarioXjuego> ProgresosXusuarioXjuegos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioXusuario> UsuarioXusuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(Configuraciones.ConexionDB);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Colore>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hexadecimal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Juego>(entity =>
            {
                entity.HasIndex(e => e.Codigo, "codigo")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ruta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Memo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PacienteId).HasColumnName("Paciente_Id");

                entity.Property(e => e.ProfesionalId).HasColumnName("Profesional_Id");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.NotaPacientes)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK_PacienteId_Notas");

                entity.HasOne(d => d.Profesional)
                    .WithMany(p => p.NotaProfesionals)
                    .HasForeignKey(d => d.ProfesionalId)
                    .HasConstraintName("FK_ProfesionalId_Notas");
            });

            modelBuilder.Entity<ProgresosXusuarioXjuego>(entity =>
            {
                entity.ToTable("ProgresosXUsuarioXJuego");

                entity.Property(e => e.FechaFinalizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.HasOne(d => d.Juego)
                    .WithMany(p => p.ProgresosXusuarioXjuegos)
                    .HasForeignKey(d => d.JuegoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Progresos__Juego__38996AB5");

                entity.HasOne(d => d.Profesional)
                    .WithMany(p => p.ProgresosXusuarioXjuegoProfesionals)
                    .HasForeignKey(d => d.ProfesionalId)
                    .HasConstraintName("FK__Progresos__Profe__6E01572D");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ProgresosXusuarioXjuegoUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Progresos__Usuar__36B12243");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TipoUsuario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreTutor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuarioId).HasColumnName("TIpoUsuarioId");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__TIpoUs__286302EC");
            });

            modelBuilder.Entity<UsuarioXusuario>(entity =>
            {
                entity.ToTable("UsuarioXUsuario");

                entity.Property(e => e.FechaFinalizacionRelacion).HasColumnType("datetime");

                entity.Property(e => e.FechaInicioRelacion).HasColumnType("datetime");

                entity.HasOne(d => d.UsuarioPaciente)
                    .WithMany(p => p.UsuarioXusuarioUsuarioPacientes)
                    .HasForeignKey(d => d.UsuarioPacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsuarioXU__Usuar__2F10007B");

                entity.HasOne(d => d.UsuarioProfesional)
                    .WithMany(p => p.UsuarioXusuarioUsuarioProfesionals)
                    .HasForeignKey(d => d.UsuarioProfesionalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsuarioXU__Usuar__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
