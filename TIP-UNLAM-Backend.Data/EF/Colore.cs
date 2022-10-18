using System;
using System.Collections.Generic;

#nullable disable

namespace TIP_UNLAM_Backend.Data.EF
{
    public partial class Colore
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Hexadecimal { get; set; }
    }
}
