﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TIP_UNLAM_Backend.Data.EF;

namespace TIP_UNLAM_Backend.Data.Migrations
{
    [DbContext(typeof(TPI_UNLAM_DB_Context))]
    [Migration("20220911225350_Usuario")]
    partial class Usuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.Juego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.ProgresosXusuarioXjuego", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Aciertos")
                        .HasColumnType("int");

                    b.Property<int>("Desaciertos")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFinalizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<int>("JuegoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioPacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioProfesionalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JuegoId");

                    b.HasIndex("UsuarioPacienteId");

                    b.HasIndex("UsuarioProfesionalId");

                    b.ToTable("ProgresosXUsuarioXJuego");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.TipoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Matricula")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("TIpoUsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.UsuarioXusuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaFinalizacionRelacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaInicioRelacion")
                        .HasColumnType("datetime");

                    b.Property<int>("UsuarioPacienteId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioProfesionalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioPacienteId");

                    b.HasIndex("UsuarioProfesionalId");

                    b.ToTable("UsuarioXUsuario");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.ProgresosXusuarioXjuego", b =>
                {
                    b.HasOne("TIP_UNLAM_Backend.Data.EF.Juego", "Juego")
                        .WithMany("ProgresosXusuarioXjuegos")
                        .HasForeignKey("JuegoId")
                        .HasConstraintName("FK__Progresos__Juego__38996AB5")
                        .IsRequired();

                    b.HasOne("TIP_UNLAM_Backend.Data.EF.Usuario", "UsuarioPaciente")
                        .WithMany("ProgresosXusuarioXjuegoUsuarioPacientes")
                        .HasForeignKey("UsuarioPacienteId")
                        .HasConstraintName("FK__Progresos__Usuar__36B12243");

                    b.HasOne("TIP_UNLAM_Backend.Data.EF.Usuario", "UsuarioProfesional")
                        .WithMany("ProgresosXusuarioXjuegoUsuarioProfesionals")
                        .HasForeignKey("UsuarioProfesionalId")
                        .HasConstraintName("FK__Progresos__Usuar__37A5467C");

                    b.Navigation("Juego");

                    b.Navigation("UsuarioPaciente");

                    b.Navigation("UsuarioProfesional");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.Usuario", b =>
                {
                    b.HasOne("TIP_UNLAM_Backend.Data.EF.TipoUsuario", "TipoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoUsuarioId")
                        .HasConstraintName("FK__Usuarios__TIpoUs__286302EC")
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.UsuarioXusuario", b =>
                {
                    b.HasOne("TIP_UNLAM_Backend.Data.EF.Usuario", "UsuarioPaciente")
                        .WithMany("UsuarioXusuarioUsuarioPacientes")
                        .HasForeignKey("UsuarioPacienteId")
                        .HasConstraintName("FK__UsuarioXU__Usuar__2F10007B")
                        .IsRequired();

                    b.HasOne("TIP_UNLAM_Backend.Data.EF.Usuario", "UsuarioProfesional")
                        .WithMany("UsuarioXusuarioUsuarioProfesionals")
                        .HasForeignKey("UsuarioProfesionalId")
                        .HasConstraintName("FK__UsuarioXU__Usuar__300424B4")
                        .IsRequired();

                    b.Navigation("UsuarioPaciente");

                    b.Navigation("UsuarioProfesional");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.Juego", b =>
                {
                    b.Navigation("ProgresosXusuarioXjuegos");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.TipoUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("TIP_UNLAM_Backend.Data.EF.Usuario", b =>
                {
                    b.Navigation("ProgresosXusuarioXjuegoUsuarioPacientes");

                    b.Navigation("ProgresosXusuarioXjuegoUsuarioProfesionals");

                    b.Navigation("UsuarioXusuarioUsuarioPacientes");

                    b.Navigation("UsuarioXusuarioUsuarioProfesionals");
                });
#pragma warning restore 612, 618
        }
    }
}
