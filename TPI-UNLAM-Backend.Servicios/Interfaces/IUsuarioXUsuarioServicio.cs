using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Procedure;

namespace TPI_UNLAM_Backend.Servicios.Interfaces
{
    public interface IUsuarioXUsuarioServicio
    {
        public List<UsuarioXusuario> getPacienteXProfesional();
        public List<UsuarioXusuario> getPacienteXProfesionalInactivos();
        public List<UsuarioXusuario> getPacienteXProfesionalActivos();
        public UsuarioXusuario getProfesionalXPaciente(int UsuarioLogeadoId);
        public void HabilitarPacientes(int pacienteId, bool estado);
        public List<vMisPacientes> MisPacientes();
    }
}
