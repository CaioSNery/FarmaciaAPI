using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Azure;
using FarmaciaSOFT.Data;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Interfaces;
using FarmaciaSOFT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaSOFT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto(Produto produtos)
        {
            var resultado = await _service.AdicionarProdutoAsync(produtos);
            return Ok(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _service.ListarProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProdutoPorId(int id)
        {
            var produto = await _service.BuscarProdutosPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produtoAtualizado)

        {
            var produto = await _service.EditarProdutoAsync(id, produtoAtualizado);
            return Ok("Atualizado com sucesso !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var delproduto = await _service.DeletarProdutoAsync(id);
            if (!delproduto)return NotFound();
        
            return Ok("Removido com sucesso !");
        }
        
    }
}