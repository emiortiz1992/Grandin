using System;
using System.Collections.Generic;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class Direccione
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public int? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
