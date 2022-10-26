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
    public class LlamadasRepositorios : ILlamadasRepositorios
    {
        private TPI_UNLAM_DB_Context _ctx;


        public LlamadasRepositorios(TPI_UNLAM_DB_Context ctx)
        {
            _ctx = ctx;
        }

        public void GuardarLlamada(Llamadum llamada)
        {
            _ctx.Llamada.Add(llamada);
        }
        public Llamadum GetLlamadaByCodigo(string codigo)
        {
            return _ctx.Llamada.Where(x => x.Codigo == codigo).FirstOrDefault();
        }

        public Llamadum obtenerLlamadaActual(int codigo)
        {
            return _ctx.Llamada.Where(x => x.PacienteId == codigo).OrderByDescending(x => x.Fecha).FirstOrDefault();

        }

        public LlamadaDto GetAllNotaXLlamada(int llamadaId)
        {
            return (
           from s in _ctx.Llamada
           join j in _ctx.Notas on s.Id equals j.LlamadaId
           where (s.Id == llamadaId)
           select new LlamadaDto
           {
               Mensaje = j.Mensaje
           }
           ).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
