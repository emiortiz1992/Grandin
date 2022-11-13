using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;

namespace TIP_UNLAM_Backend.Data.Repositorios.Interfaces
{
    public interface INotasRepositorio
    {
        public void SaveChanges();
        public List<Nota> GetAllNotasXPacienteXProfesional(int pacienteId, Usuario usuario);
        public void EliminarNota(Nota nota);
        public void GuardarNota(Nota nota);
        public Nota getNotaById(int id);
        public List<Nota> GetAllNotasXProfesional(Usuario usuario);
        public Nota getNotaXLlamado(int llamadaId);
        //public void guardarSugerencia(Sugerencia sugerencia);

    }
}
