using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Maps;
using FarmaciaSOFT.Models;

namespace FarmaciaSOFT.Interfaces
{
    public interface IProdutoRepository
    {
        Task<object> AdicionarProdutoAsync(Produto produto);

        Task<bool> EditarProdutoAsync(int id, Produto produtoupdate);

        Task<bool> DeletarProdutoAsync(int id);

        Task<IEnumerable<ProdutoDTO>> ListarProdutosAsync(int Skip = 0, int Take = 25);

        Task<object> BuscarProdutosPorId(int id);
    }
}