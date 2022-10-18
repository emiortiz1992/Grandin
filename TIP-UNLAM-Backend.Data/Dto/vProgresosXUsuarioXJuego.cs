using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIP_UNLAM_Backend.Data.Dto
{
    public class vProgresosXUsuarioXJuego
    {
        public string PacienteNombre { get; set; }
        public string PacienteApellido { get; set; }
        public string JuegoDescripcion { get; set; }
        public string ProfesionalNombre { get; set; }
        public string ProfesionalApellido { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public bool Finalizado { get; set; }
        public int Aciertos { get; set; }
        public int Desaciertos { get; set; }
        public int ProfesionalId { get; set; }


    }
}
