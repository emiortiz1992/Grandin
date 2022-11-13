using System;
using System.Collections.Generic;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class Usuario
    {
        public Usuario()
        {
            LlamadumPacientes = new HashSet<Llamadum>();
            LlamadumProfesionals = new HashSet<Llamadum>();
            NotaPacientes = new HashSet<Nota>();
            NotaProfesionals = new HashSet<Nota>();
            ProgresosXusuarioXjuegoProfesionals = new HashSet<ProgresosXusuarioXjuego>();
            ProgresosXusuarioXjuegoUsuarios = new HashSet<ProgresosXusuarioXjuego>();
            UsuarioXusuarioUsuarioPacientes = new HashSet<UsuarioXusuario>();
            UsuarioXusuarioUsuarioProfesionals = new HashSet<UsuarioXusuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Matricula { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Mail { get; set; }
        public string NombreTutor { get; set; }
        public string Telefono { get; set; }
        public int? GeneroId { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual ICollection<Llamadum> LlamadumPacientes { get; set; }
        public virtual ICollection<Llamadum> LlamadumProfesionals { get; set; }
        public virtual ICollection<Nota> NotaPacientes { get; set; }
        public virtual ICollection<Nota> NotaProfesionals { get; set; }
        public virtual ICollection<ProgresosXusuarioXjuego> ProgresosXusuarioXjuegoProfesionals { get; set; }
        public virtual ICollection<ProgresosXusuarioXjuego> ProgresosXusuarioXjuegoUsuarios { get; set; }
        public virtual ICollection<UsuarioXusuario> UsuarioXusuarioUsuarioPacientes { get; set; }
        public virtual ICollection<UsuarioXusuario> UsuarioXusuarioUsuarioProfesionals { get; set; }
    }
}
