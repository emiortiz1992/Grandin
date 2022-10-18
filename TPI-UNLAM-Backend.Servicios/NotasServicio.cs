using Microsoft.IdentityModel.SecurityTokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Repositorios.Interfaces;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Servicios
{
    public class NotasServicio : INotasServicio
    {
        private INotasRepositorio _notaRepositorio;
        private IAppSharedFunction _appSharedFunction;
        private IUsuarioXUsuarioRepositorio _userXUsuarioRepo;
        private IUsuarioRepositorio _userRepo;
        public NotasServicio(INotasRepositorio notaRepositorio, IUsuarioXUsuarioRepositorio userXUsuarioRepo, IUsuarioRepositorio userRepo, IAppSharedFunction appSharedFunction)
        {
            _notaRepositorio = notaRepositorio;
            _userXUsuarioRepo = userXUsuarioRepo;
            _userRepo = userRepo;
            _appSharedFunction = appSharedFunction;
        }

        public void EliminarNota(int notaId)
        {
            if (notaId == null)
                throw new BadRequestException("No esta enviando el Id de la nota a eliminar");

            Nota nota = _notaRepositorio.getNotaById(notaId);

            if (nota == null)
                throw new BadRequestException("No existe nota con dicho Id");

            _notaRepositorio.EliminarNota(nota);
            _notaRepositorio.SaveChanges();
        }

        public List<Nota> GetAllNotasXPacienteXProfesional(int pacienteId)
        {
            string email = _appSharedFunction.GetUsuarioPorToken();
            Usuario usuario = _userRepo.getUsuarioByEmail(email);

            if (pacienteId == null)
                throw new BadRequestException("Es obligatorio enviar el paciente");

            if (_userRepo.getUsuarioById(pacienteId) == null)
                throw new BadRequestException("No existe paciente");

            return _notaRepositorio.GetAllNotasXPacienteXProfesional(pacienteId, usuario);
        }

        public void GuardarNota(Nota nota)
        {
            if (nota.ProfesionalId == null || nota.PacienteId == null)
                throw new BadRequestException("Los campos no pueden ser nulos");
            _notaRepositorio.GuardarNota(nota);
            _notaRepositorio.SaveChanges();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
