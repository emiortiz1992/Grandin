using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIP_UNLAM_Backend.Data.Dto
{
    public class vNotasXLlamada
    {
        public int Nota_Id { get; set; }
        public string CodigoLlamada { get; set; }
        public int Llamada_Id { get; set; }
        public int Paciente_Id { get; set; }
        public int Profesional_Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
    }
}
