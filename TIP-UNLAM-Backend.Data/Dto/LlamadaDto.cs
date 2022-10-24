using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIP_UNLAM_Backend.Data.Dto
{
    public class LlamadaDto
    {
        public int Nota_Id { get; set; }
        public string CodigoLlamada { get; set; }
        public int LlamadaId { get; set; }
        public int PacienteId { get; set; }
        public int ProfesionalId { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}
