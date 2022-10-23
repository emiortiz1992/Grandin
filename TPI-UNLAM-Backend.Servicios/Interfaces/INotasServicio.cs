using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.EF;

namespace TPI_UNLAM_Backend.Servicios.Interfaces
{
    public interface INotasServicio
    {
        public void SaveChanges();
        public List<Nota> GetAllNotasXPacienteXProfesional(int pacienteId);
        public void EliminarNota(int notaId);
        public void GuardarNota(Nota nota, string codigoLlamada);
        public List<Nota> GetAllNotasXProfesional();
        public Nota getNotaXLlamado(int llamadaId);
    }
}
