using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface IFuncionRepository
    {
        List<FuncionSimpleDto> GetFunciones();
        FuncionSimpleDto GetFuncionById(int id);
        List<FuncionSimpleDto> GetFuncionByObraId(int id);
        void InsertFuncion(Funcion funcion);
        void UpdateFuncion(Funcion funcion);
        void DeleteFuncion(int id);
    }
}