using System;
using System.Collections.Generic;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class UsuarioXusuario
    {
        public int Id { get; set; }
        public int UsuarioPacienteId { get; set; }
        public int UsuarioProfesionalId { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaFinalizacionRelacion { get; set; }
        public DateTime? FechaInicioRelacion { get; set; }
        public bool? Pendiente { get; set; }

        public virtual Usuario UsuarioPaciente { get; set; }
        public virtual Usuario UsuarioProfesional { get; set; }
    }
}
