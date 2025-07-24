using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using FarmaciaSOFT.Data;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Interfaces;
using FarmaciaSOFT.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaSOFT.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<object> AdicionarProdutoAsync(Produtos produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<object> BuscarProdutosPorId(int id)
        {
            var produto = await _context.Produtos
            .Where(p => p.Id == id)
            .Select(p => new ProdutoDTO
            {
            Id = p.Id,
            Nome = p.Nome,
            Estoque = p.Estoque,
            PrecoVenda = p.PrecoVenda
            })
            .FirstOrDefaultAsync();

            if (produto == null) return false;

            return produto;
        }

        public async Task<bool> DeletarProdutoAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditarProdutoAsync(int id, Produtos produtoupdate)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            produto.Nome = produtoupdate.Nome;
            produto.Estoque = produtoupdate.Estoque;
            produto.PrecoCompra = produtoupdate.PrecoCompra;
            produto.PrecoVenda = produtoupdate.PrecoVenda;
            produto.Tipo = produtoupdate.Tipo;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProdutoDTO>> ListarProdutosAsync()
        {
            return await _context.Produtos
            .Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Estoque = p.Estoque,
                PrecoVenda = p.PrecoVenda
                

            })
            .ToListAsync();
        }
    }
}