using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;

namespace TPI_UNLAM_Backend.Servicios.Interfaces
{
    public interface IJuegoServicio
    {
        public List<Juego> getAllJuegos();
        public Juego getJuegoById(int idJuego);
        public List<Colore> getAllColores();
        public bool validarStringIguales(string campo1, string campo2);
        public void FinalizarJuego(ResultadoJuegoDto juego);
        public void SaveChanges();
        public List<int> getNumerosDesordenados();
        public string getImagenPorJuego(string codigo);
        public Boolean verificarNumerosOrdenados(List<int> numeros);
    }
}
