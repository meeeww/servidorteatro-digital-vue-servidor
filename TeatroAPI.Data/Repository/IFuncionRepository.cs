using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface IFuncionRepository
    {
        List<FuncionSimpleDto> GetFunciones();
        FuncionSimpleDto GetFuncionById(int id);
        Funcion InsertFuncion(Funcion funcion);
        void UpdateFuncion(Funcion funcion);
        void DeleteSala(int id);
    }
}