using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.SecurityTokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Repositorios.Interfaces;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Servicios
{
    public class LlamadaServicio : ILlamadaServicio
    {
        private INotasRepositorio _notaRepositorio;
        private IAppSharedFunction _appSharedFunction;
        private IUsuarioXUsuarioRepositorio _userXUsuarioRepo;
        private IUsuarioRepositorio _userRepo;
        private ILlamadasRepositorios _llamadaRepo;
        private INotasRepositorio _notaRepo;



        public LlamadaServicio(INotasRepositorio notaRepositorio, IUsuarioXUsuarioRepositorio userXUsuarioRepo, IUsuarioRepositorio userRepo, IAppSharedFunction appSharedFunction, ILlamadasRepositorios llamadaRepo, INotasRepositorio notaRepo)
        {
            _notaRepositorio = notaRepositorio;
            _userXUsuarioRepo = userXUsuarioRepo;
            _userRepo = userRepo;
            _appSharedFunction = appSharedFunction;
            _llamadaRepo = llamadaRepo;
            _notaRepo = notaRepo;

        }

        public LlamadaDto GetAllNotaXLlamada(int llamadaId)
        {
            return _llamadaRepo.GetAllNotaXLlamada(llamadaId);
        }
        public Llamadum GetLlamadaByCodigo(string codigo)
        {
            return _llamadaRepo.GetLlamadaByCodigo(codigo);
        }

        public void GuardarLlamada(LlamadaDto call)
        {
            string emailUsuarioLogueado = _appSharedFunction.GetUsuarioPorToken();
            Nota nota = new Nota();
            if (_userRepo.getUsuarioByEmail(emailUsuarioLogueado) == null)
                throw new BadRequestException("No existe usuario");

            Usuario usuarioLogueado = _userRepo.getUsuarioByEmail(emailUsuarioLogueado);

            Llamadum llamada = new Llamadum();
            llamada.Codigo = call.CodigoLlamada;
            llamada.ProfesionalId = usuarioLogueado.Id;
            llamada.PacienteId = call.PacienteId;
            llamada.Fecha = call.Fecha;

            _llamadaRepo.GuardarLlamada(llamada);
            _llamadaRepo.SaveChanges();

        }


        public LlamadaDto obtenerLlamadaActual()
        {
            string emailUsuarioLogueado = _appSharedFunction.GetUsuarioPorToken();
            Usuario usuarioLogueado = _userRepo.getUsuarioByEmail(emailUsuarioLogueado);
            Llamadum llamadaObj = _llamadaRepo.obtenerLlamadaActual(usuarioLogueado.Id);
            
            LlamadaDto llamadaDto = new LlamadaDto();
            llamadaDto.CodigoLlamada = llamadaObj.Codigo;

            return llamadaDto;
        }

        public void SaveChanges()
        {
            _llamadaRepo.SaveChanges();
        }
    }
}
