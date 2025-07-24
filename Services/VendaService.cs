using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Data;
using FarmaciaSOFT.Interfaces;
using FarmaciaSOFT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FarmaciaSOFT.Services
{
    public class VendaService : IVendaService
    {
        private readonly AppDbContext _context;
        private readonly ISMSService _smsService;

         public VendaService(AppDbContext context, ISMSService smsService)
        {
         _context = context;
        _smsService = smsService;
        }

        public async Task<IEnumerable<Venda>> ListarVendasAsync()
        {
            return await _context.Venda.ToListAsync();
        }

        public async Task<Venda> BuscarVendasPorIdAsync(int id)
        {
            return await _context.Venda.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<object> RealizarVendaAsync(VendasDTO vendaDto)
        {
            var cliente = await _context.Clientes.FindAsync(vendaDto.ClienteId);
            var produto = await _context.Produtos.FindAsync(vendaDto.ProdutoId);

            if (produto == null) return "Produto nao encontrado";
            if (vendaDto.Quantidade <= 0) return "Quantidade inválida";
            if (produto.Estoque < vendaDto.Quantidade) return "Estoque insuficiente";

            decimal ValorUnitario;
            if (cliente != null)
            {
                ValorUnitario = produto.PrecoVenda * 0.9M;
            }
            else
            {
                ValorUnitario = produto.PrecoVenda;
            }

            decimal ValorTotal = ValorUnitario * vendaDto.Quantidade;
            produto.Estoque -= vendaDto.Quantidade;

            if (produto.Estoque == 0)
            {
                _context.Produtos.Remove(produto);

            }
            else
            {
                _context.Produtos.Update(produto);
            }


            var venda = new Venda
            {
                NomeProduto=produto.Nome,
                ProdutoId =vendaDto.ProdutoId,
                ClienteId=vendaDto.ClienteId,
                Quantidade = vendaDto.Quantidade,
                ValorUnitario = ValorUnitario,
                Total = ValorTotal,
                DataVenda = DateTime.Now,
                

            };

            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();

            
            

             if (cliente != null && produto != null)
            {
                string msg = $"Olá {cliente.Nome}, sua compra de {venda.Quantidade}x {produto.Nome} foi registrada com sucesso!";
                await _smsService.EnviarSMSAsync(cliente.Telefone, msg);
            }

            return new
            {
                Mensagem = "Venda Realizada com Sucesso !",
                Cliente = cliente?.Nome ?? "Cliente nao Identificado",
                Produto = produto.Nome,
                Quantidade = vendaDto.Quantidade,
                ValorUnitarioComDesconto = ValorUnitario,
                Total = ValorTotal
            };

            }

       
    }
    }
