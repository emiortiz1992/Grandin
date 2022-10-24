using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;

namespace TPI_UNLAM_Backend.Servicios.Interfaces
{
    public interface ILlamadaServicio
    {
        public void SaveChanges();
        public vNotasXLlamada GetAllNotaXLlamada(int llamadaId);
        public void GuardarLlamada(vNotasXLlamada llamada);
        public Llamadum GetLlamadaByCodigo(string codigo);
    }
}
