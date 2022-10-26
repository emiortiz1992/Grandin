using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;

namespace TIP_UNLAM_Backend.Data.Repositorios.Interfaces
{
    public interface ILlamadasRepositorios
    {
        public LlamadaDto GetAllNotaXLlamada(int llamadaId);
        public void GuardarLlamada(Llamadum llamada);
        public void SaveChanges();
        public Llamadum GetLlamadaByCodigo(string codigo);

        public Llamadum obtenerLlamadaActual(int codigo);
    }
}
