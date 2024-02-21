using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface ISesionRepository
    {
        SesionDto GetSesionPorToken(string token);
        List<SesionDto> GetSesionesPorId(int id);
        void CrearSesion(Sesion sesion);
        void FinalizarSesion(string token);
    }
}