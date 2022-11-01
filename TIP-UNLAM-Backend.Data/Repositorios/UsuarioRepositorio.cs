using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Repositorios.Interfaces;

namespace TIP_UNLAM_Backend.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private TPI_UNLAM_DB_Context _ctx;

        public UsuarioRepositorio(TPI_UNLAM_DB_Context ctx)
        {
            _ctx = ctx;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            _ctx.Add(usuario);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
        public Usuario getUsuarioByEmail(string mail)
        {
            return _ctx.Usuarios.Where(x => x.Mail == mail).FirstOrDefault();
        }

        public Usuario getUsuarioById(int id)
        {
            return _ctx.Usuarios.Find(id);
        }

        public List<Usuario> getAllUsuariosProfesionalesActivos()
        {
            return _ctx.Usuarios.Where(x => x.TipoUsuario.Descripcion == "Profesional" && x.Activo == true).ToList();
        }

        public List<Usuario> getAllUsuariosProfesionalesInactivos()
        {
            return _ctx.Usuarios.Where(x => x.TipoUsuario.Descripcion == "Profesional" && x.Activo == false).ToList();
        }

        public List<Usuario> getAllUsuariosProfesionales()
        {
            return _ctx.Usuarios.Where(x => x.TipoUsuario.Descripcion == "Profesional").ToList();
        }

        public List<Usuario> getAllUsuariosPacientesActivos()
        {
            return _ctx.Usuarios.Where(x => x.TipoUsuario.Descripcion == "Paciente" && x.Activo == true).ToList();
        }

        public List<Usuario> getAllUsuariosPacientesInactivos()
        {
            return _ctx.Usuarios.Where(x => x.TipoUsuario.Descripcion == "Paciente" && x.Activo == false).ToList();
        }

        public List<Usuario> getAllUsuariosPacientes()
        {
            return _ctx.Usuarios.Where(x => x.TipoUsuario.Descripcion == "Paciente").ToList();
        }
    }
}
