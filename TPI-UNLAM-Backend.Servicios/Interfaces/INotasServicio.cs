using Microsoft.AspNetCore.Mvc;
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
        public void GuardarNotaEnLlamada(Nota nota, string codigoLlamada);
        //public void GuardarNota(Nota nota);
        public void GuardarNota([FromBody] Nota nota);
        public List<Nota> GetAllNotasXProfesional();
        public Nota getNotaXLlamado(int llamadaId);
        //public void guardarSugerencia(Sugerencia sugerencia);
    }
}
