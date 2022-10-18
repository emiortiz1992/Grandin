using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Repositorios.Interfaces;

namespace TIP_UNLAM_Backend.Data.Repositorios
{
    public class JuegoRepositorio : IJuegoRepositorio
    {
        private TPI_UNLAM_DB_Context _ctx;

        public JuegoRepositorio(TPI_UNLAM_DB_Context ctx)
        {
            _ctx = ctx;
        }

        public List<Juego> getAllJuegos()
        {
            return _ctx.Juegos.OrderBy(x => x.Codigo).ToList();
        }

        public Juego getJuegoById(int idJuego)
        {
            return _ctx.Juegos.Find(idJuego);
        }

        public void FinalizarJuego(ProgresosXusuarioXjuego juego)
        {
            _ctx.Add(juego);
        }

        public Juego getImagenPorJuego(string codigo)
        {
            return _ctx.Juegos.Where(x => x.Codigo == codigo).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public List<Colore> getAllColores()
        {
            return _ctx.Colores.ToList();
        }
            
    }
}
