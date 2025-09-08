using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Models;

namespace FarmaciaSOFT.Interfaces
{
    public interface IVendaRepository
    {
        Task<object> RealizarVendaAsync(VendasDTO vendaDto);
        Task<IEnumerable<Venda>> ListarVendasAsync(int Skip = 0, int Take = 25);
        Task<Venda> BuscarVendasPorIdAsync(int id);
    }
}