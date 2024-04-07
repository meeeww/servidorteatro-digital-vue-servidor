using TeatroAPI.Data;
using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Services
{
    public class ObraService
    {
        private readonly IObraRepository _obraRepository;

        public ObraService(IObraRepository obraRepository)
        {
            _obraRepository = obraRepository;
        }

        public List<ObraSimpleDto> GetObras()
        {
            return _obraRepository.GetObras();
        }

        public ObraReservaDto GetObraById(int id)
        {
            return _obraRepository.GetObraById(id);
        }

        public List<ObraSimpleDto> GetObraCategoriaById(int id)
        {
            return _obraRepository.GetObraCategoriaById(id);
        }

        public Obra InsertObra(Obra obra)
        {
            _obraRepository.InsertObra(obra);

            return obra;
        }

        public void UpdateObra(Obra obra)
        {
            _obraRepository.UpdateObra(obra);
        }

        public void DeleteObra(int id)
        {
            _obraRepository.DeleteObra(id);
        }
    }
}

