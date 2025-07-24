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
        Task<object> AdicionarProdutoAsync(Produto produto);

        Task<bool> EditarProdutoAsync(int id, Produto produtoupdate);

        Task<bool> DeletarProdutoAsync(int id);

        Task<IEnumerable<ProdutoDTO>> ListarProdutosAsync();

        Task<object> BuscarProdutosPorId(int id);
    }
}