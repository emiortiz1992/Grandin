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
    public class ProgresosXUsuarioXJuegoRepositorio : IProgresosXUsuarioXJuegoRepositorio
    {
        private TPI_UNLAM_DB_Context _ctx;

        public ProgresosXUsuarioXJuegoRepositorio(TPI_UNLAM_DB_Context ctx)
        {
            _ctx = ctx;
        }

        public List<vProgresosXUsuarioXJuego> getAllProgresoXPaciente(Usuario paciente)
        {
            return (
            from s in _ctx.ProgresosXusuarioXjuegos
            join j in _ctx.Juegos on s.JuegoId equals j.Id
            join p1 in _ctx.Usuarios on s.UsuarioId equals p1.Id
            join p2 in _ctx.Usuarios on s.ProfesionalId equals p2.Id
            where (s.UsuarioId == paciente.Id)
            select new vProgresosXUsuarioXJuego
            {
                PacienteApellido = p1.Apellido,
                PacienteNombre = p1.Nombre,
                JuegoDescripcion = j.Descripcion,
                ProfesionalNombre = p2.Nombre,
                ProfesionalApellido = p2.Apellido,
                Aciertos = s.Aciertos,
                Desaciertos = s.Desaciertos,
                FechaFinalizacion = s.FechaFinalizacion,
                FechaInicio = s.FechaInicio,
                Finalizado = s.Finalizado,
                Duracion = String.Format("{0:00}:{1:00}:{2:00}", s.FechaFinalizacion.Subtract(s.FechaInicio).Hours, s.FechaFinalizacion.Subtract(s.FechaInicio).Minutes, s.FechaFinalizacion.Subtract(s.FechaInicio).Seconds)
            }
            ).ToList();
        }

        public List<vProgresosXUsuarioXJuego> getAllProgresoXProfesional(Usuario Profesional)
        {
            return (
            from s in _ctx.ProgresosXusuarioXjuegos
            join j in _ctx.Juegos on s.JuegoId equals j.Id
            join p1 in _ctx.Usuarios on s.UsuarioId equals p1.Id
            join p2 in _ctx.Usuarios on s.ProfesionalId equals p2.Id
            where (s.ProfesionalId == Profesional.Id)
            select new vProgresosXUsuarioXJuego
            {
                PacienteApellido = p1.Apellido,
                PacienteNombre = p1.Nombre,
                JuegoDescripcion = j.Descripcion,
                ProfesionalNombre = p2.Nombre,
                ProfesionalApellido = p2.Apellido,
                Aciertos = s.Aciertos,
                Desaciertos = s.Desaciertos,
                FechaFinalizacion = s.FechaFinalizacion,
                FechaInicio = s.FechaInicio,
                Finalizado = s.Finalizado,
                Duracion = String.Format("{0:00}:{1:00}:{2:00}", s.FechaFinalizacion.Subtract(s.FechaInicio).Hours, s.FechaFinalizacion.Subtract(s.FechaInicio).Minutes, s.FechaFinalizacion.Subtract(s.FechaInicio).Seconds)
            }
            ).ToList();

        }

        public vProgresosXUsuarioXJuego getAllProgresoXPacienteXJuego(Usuario paciente, int juegoId)
        {
            return (
           from s in _ctx.ProgresosXusuarioXjuegos
           join j in _ctx.Juegos on s.JuegoId equals j.Id
           join p1 in _ctx.Usuarios on s.UsuarioId equals p1.Id
           join p2 in _ctx.Usuarios on s.ProfesionalId equals p2.Id
           where (s.UsuarioId == paciente.Id && s.JuegoId == juegoId)
           select new vProgresosXUsuarioXJuego
           {
               PacienteApellido = p1.Apellido,
               PacienteNombre = p1.Nombre,
               JuegoDescripcion = j.Descripcion,
               ProfesionalNombre = p2.Nombre,
               ProfesionalApellido = p2.Apellido,
               Aciertos = s.Aciertos,
               Desaciertos = s.Desaciertos,
               FechaFinalizacion = s.FechaFinalizacion,
               FechaInicio = s.FechaInicio,
               Finalizado = s.Finalizado,
               Duracion = String.Format("{0:00}:{1:00}:{2:00}", s.FechaFinalizacion.Subtract(s.FechaInicio).Hours, s.FechaFinalizacion.Subtract(s.FechaInicio).Minutes, s.FechaFinalizacion.Subtract(s.FechaInicio).Seconds)
           }
           ).FirstOrDefault();

        }

        public List<vProgresosXUsuarioXJuego> getProgresoXPacienteXJuegoXProfesional(int pacienteId, int juegoId, Usuario profesional)
        {
            return (
          from s in _ctx.ProgresosXusuarioXjuegos
          join j in _ctx.Juegos on s.JuegoId equals j.Id
          join p1 in _ctx.Usuarios on s.UsuarioId equals p1.Id
          join p2 in _ctx.Usuarios on s.ProfesionalId equals p2.Id
          where (s.UsuarioId == pacienteId && s.JuegoId == juegoId && s.ProfesionalId == profesional.Id)
          select new vProgresosXUsuarioXJuego
          {
              PacienteApellido = p1.Apellido,
              PacienteNombre = p1.Nombre,
              JuegoDescripcion = j.Descripcion,
              ProfesionalNombre = p2.Nombre,
              ProfesionalApellido = p2.Apellido,
              Aciertos = s.Aciertos,
              Desaciertos = s.Desaciertos,
              FechaFinalizacion = s.FechaFinalizacion,
              FechaInicio = s.FechaInicio,
              Finalizado = s.Finalizado,
              Duracion = String.Format("{0:00}:{1:00}:{2:00}", s.FechaFinalizacion.Subtract(s.FechaInicio).Hours, s.FechaFinalizacion.Subtract(s.FechaInicio).Minutes, s.FechaFinalizacion.Subtract(s.FechaInicio).Seconds)
          }
          ).ToList();

        }

        public List<vProgresosXUsuarioXJuego> getProgresoXProfesionalXPaciente(int pacienteId, Usuario profesional)
        {
            return (
         from s in _ctx.ProgresosXusuarioXjuegos
         join j in _ctx.Juegos on s.JuegoId equals j.Id
         join p1 in _ctx.Usuarios on s.UsuarioId equals p1.Id
         join p2 in _ctx.Usuarios on s.ProfesionalId equals p2.Id
         where (s.UsuarioId == pacienteId && s.ProfesionalId == profesional.Id)
         select new vProgresosXUsuarioXJuego
         {
             PacienteApellido = p1.Apellido,
             PacienteNombre = p1.Nombre,
             JuegoDescripcion = j.Descripcion,
             ProfesionalNombre = p2.Nombre,
             ProfesionalApellido = p2.Apellido,
             Aciertos = s.Aciertos,
             Desaciertos = s.Desaciertos,
             FechaFinalizacion = s.FechaFinalizacion,
             FechaInicio = s.FechaInicio,
             Finalizado = s.Finalizado,
             Duracion = String.Format("{0:00}:{1:00}:{2:00}", s.FechaFinalizacion.Subtract(s.FechaInicio).Hours, s.FechaFinalizacion.Subtract(s.FechaInicio).Minutes, s.FechaFinalizacion.Subtract(s.FechaInicio).Seconds)
            
         }
         ).ToList();

        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

    }
}
