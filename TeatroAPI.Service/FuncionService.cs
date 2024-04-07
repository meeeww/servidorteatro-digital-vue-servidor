using TeatroAPI.Data;
using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Services
{
    public class FuncionService
    {
        private readonly IFuncionRepository _funcionRepository;

        public FuncionService(IFuncionRepository funcionRepository)
        {
            _funcionRepository = funcionRepository;
        }

        public List<FuncionSimpleDto> GetFunciones()
        {
            return _funcionRepository.GetFunciones();
        }

        public FuncionSimpleDto GetFuncionById(int id)
        {
            return _funcionRepository.GetFuncionById(id);
        }

        public List<FuncionSimpleDto> GetFuncionByObraId(int id)
        {
            return _funcionRepository.GetFuncionByObraId(id);
        }

        public Funcion InsertFuncion(Funcion funcion)
        {
            _funcionRepository.InsertFuncion(funcion);

            return funcion;
        }

        public void UpdateFuncion(Funcion funcion)
        {
            _funcionRepository.InsertFuncion(funcion);
        }

        public void DeleteFuncion(int id)
        {
            _funcionRepository.DeleteFuncion(id);
        }
    }
}

