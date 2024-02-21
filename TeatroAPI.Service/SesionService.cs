using TeatroAPI.Data;
using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Services
{
    public class SesionService
    {
        private readonly ISesionRepository _sesionRepository;

        public SesionService(ISesionRepository sesionRepository)
        {
            _sesionRepository = sesionRepository;
        }

        public SesionDto GetSesionPorToken(string token)
        {
            return _sesionRepository.GetSesionPorToken(token);
        }

        public List<SesionDto> GetSesionesPorId(int id)
        {
            return _sesionRepository.GetSesionesPorId(id);
        }

        public Sesion CrearSesion(Sesion sesion)
        {
            _sesionRepository.CrearSesion(sesion);

            return sesion;
        }

        public void FinalizarSesion(string token)
        {
            _sesionRepository.FinalizarSesion(token);
        }
    }
}

