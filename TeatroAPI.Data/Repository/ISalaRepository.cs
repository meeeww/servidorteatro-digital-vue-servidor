using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface ISalaRepository
    {
        List<SalaSimpleDto> GetSalas();
        SalaSimpleDto GetSalaById(int id);
        SalaSimpleDto GetSalaByName(string name);
        void InsertSala(Sala sala);
        void UpdateSala(Sala sala);
        void DeleteSala(int id);
    }
}