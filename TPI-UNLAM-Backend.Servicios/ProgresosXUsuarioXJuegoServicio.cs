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
    public class ProgresosXUsuarioXJuegoServicio : IProgresosXUsuarioXJuegoServicio
    {

        private IAppSharedFunction _appSharedFunction;
        private IProgresosXUsuarioXJuegoRepositorio _progresoRepo;
        private IUsuarioRepositorio _userRepo;


        public ProgresosXUsuarioXJuegoServicio(IAppSharedFunction appSharedFunction, IProgresosXUsuarioXJuegoRepositorio progreso, IUsuarioRepositorio userRepo)
        {
            _appSharedFunction = appSharedFunction;
            _progresoRepo = progreso;
            _userRepo = userRepo;
        }

        public List<vProgresosXUsuarioXJuego> getAllProgresoXPaciente()
        {
            string mailPacienteLogueado = _appSharedFunction.GetUsuarioPorToken();

            Usuario paciente = _userRepo.getUsuarioByEmail(mailPacienteLogueado);

            return _progresoRepo.getAllProgresoXPaciente(paciente);
        }

        public vProgresosXUsuarioXJuego getAllProgresoXPacienteXJuego(int juegoId)
        {
            string mailPacienteLogueado = _appSharedFunction.GetUsuarioPorToken();

            Usuario paciente = _userRepo.getUsuarioByEmail(mailPacienteLogueado);

            return _progresoRepo.getAllProgresoXPacienteXJuego(paciente, juegoId);
        }

        public List<vProgresosXUsuarioXJuego> getAllProgresoXProfesional()
        {
            string mailProfesionalLogueado = _appSharedFunction.GetUsuarioPorToken();

            Usuario profesional = _userRepo.getUsuarioByEmail(mailProfesionalLogueado);
            return _progresoRepo.getAllProgresoXProfesional(profesional);
        }

        public vProgresosXUsuarioXJuego getProgresoXPacienteXJuegoXProfesional(int pacienteId, int juegoid)
        {
            string mailProfesionalLogueado = _appSharedFunction.GetUsuarioPorToken();

            Usuario profesional = _userRepo.getUsuarioByEmail(mailProfesionalLogueado);
            return _progresoRepo.getProgresoXPacienteXJuegoXProfesional(pacienteId, juegoid, profesional);
        }

        public List<vProgresosXUsuarioXJuego> getProgresoXProfesionalXPaciente(int pacienteId)
        {
            string mailProfesionalLogueado = _appSharedFunction.GetUsuarioPorToken();

            Usuario profesional = _userRepo.getUsuarioByEmail(mailProfesionalLogueado);
            return _progresoRepo.getProgresoXProfesionalXPaciente(pacienteId, profesional);
        }

        public void SaveChanges()
        {
            _progresoRepo.SaveChanges();
        }
    }
}
