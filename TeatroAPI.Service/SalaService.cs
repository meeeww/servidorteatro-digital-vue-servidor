using TeatroAPI.Data;
using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Services
{
    public class SalaService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaService(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public List<SalaSimpleDto> GetSalas()
        {
            return _salaRepository.GetSalas();
        }

        public SalaSimpleDto GetSalaById(int id)
        {
            return _salaRepository.GetSalaById(id);
        }

        public SalaSimpleDto GetSalaByName(string name)
        {
            return _salaRepository.GetSalaByEmail(name);
        }

        public Sala InsertSala(Sala sala)
        {
            _salaRepository.InsertSala(sala);

            return sala;
        }

        public void UpdateSala(Sala sala)
        {
            _salaRepository.InsertSala(sala);
        }

        public void DeleteSala(int id)
        {
            _salaRepository.DeleteSala(id);
        }
    }
}

