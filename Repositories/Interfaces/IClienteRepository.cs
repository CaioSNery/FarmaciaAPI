using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Models;

namespace FarmaciaSOFT.Interfaces
{
    public interface IClienteRepository
    {
        Task<object> AddClienteAsync(Cliente clientes);

        Task<object> BuscarClientePorIdAsync(int id);

        Task<bool> DeletarClientePorIdAsync(int id);

        Task<IEnumerable<ClienteDTO>> ListarClienteAsync(int Skip = 0, int Take = 25);

        Task<bool> EditarClienteAsync(int id, Cliente clienteupdate);

    }
}