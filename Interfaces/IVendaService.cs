using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Models;

namespace FarmaciaSOFT.Interfaces
{
    public interface IVendaService
    {
         Task<object> RealizarVendaAsync(VendasDTO vendaDto);
         Task<IEnumerable<Venda>> ListarVendasAsync();
         Task<Venda> BuscarVendasPorIdAsync(int id);
    }
}