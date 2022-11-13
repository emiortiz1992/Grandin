using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIP_UNLAM_Backend.Data.Procedure
{
    public class vMisPacientes
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; }
        public string PacienteApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime? FechaInicioRelac { get; set; }
        public DateTime? FechaFinRelac { get; set; }
        public string Direccion { get; set; }
        public string NombreTutor { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public bool Estado { get; set; }
    }
}
