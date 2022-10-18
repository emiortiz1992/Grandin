using TPI_UNLAM_Backend.Models;

namespace TPI_UNLAM_Backend.Servicios.Interfaces
{
    public interface IAppSharedFunction
    {
        public UserTokenDto BuildTokenUsuario(string usuario, string password);
        public string GetUsuarioPorToken();
    }
}
