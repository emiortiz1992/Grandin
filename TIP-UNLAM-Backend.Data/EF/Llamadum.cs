using System;
using System.Collections.Generic;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class Llamadum
    {
        public Llamadum()
        {
            Nota = new HashSet<Nota>();
        }

        public int Id { get; set; }
        public int? ProfesionalId { get; set; }
        public int? PacienteId { get; set; }
        public DateTime? Fecha { get; set; }
        public string Codigo { get; set; }

        public virtual Usuario Paciente { get; set; }
        public virtual Usuario Profesional { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
