using BankAPI.DTOs;
using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IClientesRepository
    {
        List<ClienteDto> GetClientes();
        ClienteDto GetClienteById(int id);
        ClienteDto GetClienteByEmail(string email);
        void InsertCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
    }
}