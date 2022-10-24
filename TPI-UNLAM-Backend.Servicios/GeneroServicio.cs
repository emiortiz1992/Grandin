using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Repositorios.Interfaces;
using TPI_UNLAM_Backend.Servicios.Interfaces;

namespace TPI_UNLAM_Backend.Servicios
{
    public class GeneroServicio : IGeneroServicio
    {
        private IGeneroRepositorio _generoRepo;

        private IAppSharedFunction _appSharedFunction;

        public GeneroServicio(IGeneroRepositorio generoRepo, IAppSharedFunction appSharedFunction)
        {
            _generoRepo = generoRepo;
            _appSharedFunction = appSharedFunction;
        }
        public List<Genero> getAllGeneros()
        {
            return _generoRepo.getAllGeneros();
        }
    }
}
