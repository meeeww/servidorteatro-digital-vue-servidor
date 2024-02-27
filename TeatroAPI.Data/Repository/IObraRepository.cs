using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface IObraRepository
    {
        List<ObraSimpleDto> GetObras();
        ObraSimpleDto GetObraById(int id);
        Obra InsertObra(Obra obra);
        void UpdateObra(Obra obra);
        void DeleteSala(int id);
    }
}