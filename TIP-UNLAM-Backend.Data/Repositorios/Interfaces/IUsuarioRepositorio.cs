using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;

namespace TIP_UNLAM_Backend.Data.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public void AgregarUsuario(Usuario usuario);
        public Usuario getUsuarioByEmail(string email);
        public void SaveChanges();
        public Usuario getUsuarioById(int id);
        public List<Usuario> getAllUsuariosProfesionalesActivos();
        public List<Usuario> getAllUsuariosProfesionalesInactivos();
        public List<Usuario> getAllUsuariosProfesionales();
        public List<Usuario> getAllUsuariosPacientesActivos();
        public List<Usuario> getAllUsuariosPacientesInactivos();
        public List<Usuario> getAllUsuariosPacientes();
       
    }
}
