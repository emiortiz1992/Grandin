using System;
using System.Collections.Generic;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class Sugerencia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Mail { get; set; }
    }
}
