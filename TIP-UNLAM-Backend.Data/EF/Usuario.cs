using System;
using System.Collections.Generic;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class Usuario
    {
        public Usuario()
        {
            LlamadaPacientes = new HashSet<Llamada>();
            LlamadaProfesionals = new HashSet<Llamada>();
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
        public string Direccion { get; set; }

        public virtual Genero Genero { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        public virtual ICollection<Llamada> LlamadaPacientes { get; set; }
        public virtual ICollection<Llamada> LlamadaProfesionals { get; set; }
        public virtual ICollection<ProgresosXusuarioXjuego> ProgresosXusuarioXjuegoProfesionals { get; set; }
        public virtual ICollection<ProgresosXusuarioXjuego> ProgresosXusuarioXjuegoUsuarios { get; set; }
        public virtual ICollection<UsuarioXusuario> UsuarioXusuarioUsuarioPacientes { get; set; }
        public virtual ICollection<UsuarioXusuario> UsuarioXusuarioUsuarioProfesionals { get; set; }
    }
}
