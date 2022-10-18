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
    public class NotasRepositorio : INotasRepositorio
    {
        private TPI_UNLAM_DB_Context _ctx;

        public NotasRepositorio(TPI_UNLAM_DB_Context ctx)
        {
            _ctx = ctx;
        }

        public void GuardarNota(Nota nota)
        {
            _ctx.Add(nota);
        }

        public void EliminarNota(Nota nota)
        {
            _ctx.Remove(nota);
        }

        public Nota getNotaById(int id)
        {
            return _ctx.Notas.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Nota> GetAllNotasXPacienteXProfesional(int pacienteId, Usuario usuario)
        {
            return _ctx.Notas.Where(x => x.PacienteId == pacienteId && x.ProfesionalId == usuario.Id).ToList();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

     
    }
}
