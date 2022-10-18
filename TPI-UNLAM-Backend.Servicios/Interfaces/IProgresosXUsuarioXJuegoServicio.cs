using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;

namespace TPI_UNLAM_Backend.Servicios.Interfaces
{
    public interface IProgresosXUsuarioXJuegoServicio
    {
        public List<vProgresosXUsuarioXJuego> getAllProgresoXPaciente();
        public List<vProgresosXUsuarioXJuego> getAllProgresoXProfesional();
        public vProgresosXUsuarioXJuego getAllProgresoXPacienteXJuego(int juegoId);
        public vProgresosXUsuarioXJuego getProgresoXPacienteXJuegoXProfesional(int pacienteId, int juegoid);

        public List<vProgresosXUsuarioXJuego> getProgresoXProfesionalXPaciente(int pacienteId);
        public void SaveChanges();
    }
}
