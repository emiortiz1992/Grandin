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
        private ILlamadasRepositorios _llamadaRepositorio;
        private IAppSharedFunction _appSharedFunction;
        private IUsuarioXUsuarioRepositorio _userXUsuarioRepo;
        private IUsuarioRepositorio _userRepo;
        public NotasServicio(INotasRepositorio notaRepositorio, IUsuarioXUsuarioRepositorio userXUsuarioRepo, IUsuarioRepositorio userRepo, IAppSharedFunction appSharedFunction, ILlamadasRepositorios llamadaRepositorio)
        {
            _notaRepositorio = notaRepositorio;
            _userXUsuarioRepo = userXUsuarioRepo;
            _userRepo = userRepo;
            _appSharedFunction = appSharedFunction;
            _llamadaRepositorio = llamadaRepositorio;
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

        public List<Nota> GetAllNotasXProfesional()
        {
            string email = _appSharedFunction.GetUsuarioPorToken();
            Usuario usuario = _userRepo.getUsuarioByEmail(email);

            return _notaRepositorio.GetAllNotasXProfesional(usuario);
        }

        public void GuardarNotaEnLlamada(Nota nota, string codigoLlamada)
        {
            if (nota.ProfesionalId == null || nota.PacienteId == null)
                throw new BadRequestException("Los campos no pueden ser nulos");

            Llamadum llamado = _llamadaRepositorio.GetLlamadaByCodigo(codigoLlamada);
            nota.LlamadaId = llamado.Id;

            _notaRepositorio.GuardarNota(nota);
            _notaRepositorio.SaveChanges();
        }
        public void GuardarNota(Nota nota)
        {
            if (nota.ProfesionalId == null || nota.PacienteId == null)
                throw new BadRequestException("Los campos no pueden ser nulos");

            nota.LlamadaId = null;

            _notaRepositorio.GuardarNota(nota);
            _notaRepositorio.SaveChanges();
        }

        public Nota getNotaXLlamado(int llamadaId)
        {
            return _notaRepositorio.getNotaXLlamado(llamadaId);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        //public void guardarSugerencia(Sugerencia sugerencia)
        //{
        //    _notaRepositorio.guardarSugerencia(sugerencia);
        //    _notaRepositorio.SaveChanges();
        //}
    }
}
