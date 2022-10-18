using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;

namespace TPI_UNLAM_Backend.Servicios.Interfaces
{
    public interface IUsuarioServicio
    {
        public string AgregarUsuario(UsuarioDto usuario);
        public Usuario getUsuarioByEmail(string email);
        public Usuario getUsuarioById(int id);
        public UsuarioDto Login(LoginDto loginDto);
        public void SaveChanges();
        public void modificarUsuario(Usuario usuario);
        public void agregarRelacion(UsuarioDto usuario);
        public string HabilitarProfesional(int id, bool estado);
        public List<Usuario> getAllUsuariosProfesionalesActivos();
        public List<Usuario> getAllUsuariosProfesionalesInactivos();
        public List<Usuario> getAllUsuariosProfesionales();
        public List<Usuario> getAllUsuariosPacientesActivos();
        public List<Usuario> getAllUsuariosPacientesInactivos();
        public List<Usuario> getAllUsuariosPacientes();
    }
}
