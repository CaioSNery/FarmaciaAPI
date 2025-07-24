using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Models;

namespace FarmaciaSOFT.Interfaces
{
    public interface IClienteService
    {
        Task<object> AddClienteAsync(Cliente clientes);

        Task<object> BuscarClientePorIdAsync(int id);

        Task<bool> DeletarClientePorIdAsync(int id);

        Task<IEnumerable<ClienteDTO>> ListarClienteAsync();

        Task<bool> EditarClienteAsync(int id, Cliente clienteupdate);

    }
}