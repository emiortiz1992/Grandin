using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Repositorios.Interfaces;

namespace TIP_UNLAM_Backend.Data.Repositorios
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        private TPI_UNLAM_DB_Context _ctx;

        public GeneroRepositorio(TPI_UNLAM_DB_Context ctx)
        {
            _ctx = ctx;
        }
        public List<Genero> getAllGeneros()
        {
            return _ctx.Generos.ToList();
        }
    }
}
