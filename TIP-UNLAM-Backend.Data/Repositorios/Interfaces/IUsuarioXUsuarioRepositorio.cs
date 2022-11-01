using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Procedure;

namespace TIP_UNLAM_Backend.Data.Repositorios.Interfaces
{
    public interface IUsuarioXUsuarioRepositorio
    {
        public void SaveChanges();
        public void agregarRelacion(UsuarioXusuario usuarioxusuario);
        public List<UsuarioXusuario> getPacienteXProfesional(int UsuarioLogeadoId);
        public List<UsuarioXusuario> getPacienteXProfesionalInactivos(int UsuarioLogeadoId);
        public List<UsuarioXusuario> getPacienteXProfesionalActivos(int UsuarioLogeadoId);
        public UsuarioXusuario HabilitarPacienteXProfesional(int UsuarioLogeadoId, int pacienteId);
        public UsuarioXusuario getProfesionalXPaciente(int UsuarioLogeadoId);
        public List<vMisPacientes> MisPacientes(int profesionalId);
    }
}
