using System;
using System.Collections.Generic;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class ProgresosXusuarioXjuego
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int JuegoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public bool Finalizado { get; set; }
        public int Aciertos { get; set; }
        public int Desaciertos { get; set; }
        public int? ProfesionalId { get; set; }

        public virtual Juego Juego { get; set; }
        public virtual Usuario Profesional { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
