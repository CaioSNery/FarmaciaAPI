using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Maps;
using FarmaciaSOFT.Models;

namespace FarmaciaSOFT.Interfaces
{
    public interface IProdutoService
    {
        Task<object> AdicionarProdutoAsync(Produtos produto);

        Task<bool> EditarProdutoAsync(int id, Produtos produtoupdate);

        Task<bool> DeletarProdutoAsync(int id);

        Task<IEnumerable<ProdutoDTO>> ListarProdutosAsync();

        Task<object> BuscarProdutosPorId(int id);
    }
}