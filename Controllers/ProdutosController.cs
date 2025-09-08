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
    [Route("v1")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _service;

        public ProdutosController(IProdutoRepository service)
        {
            _service = service;
        }

        [HttpPost("produtos")]
        public async Task<IActionResult> AdicionarProduto(Produto produtos)
        {
            var resultado = await _service.AdicionarProdutoAsync(produtos);
            return Ok(resultado);
        }
        [HttpGet("produtos")]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _service.ListarProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet("produtos/{id:int}")]
        public async Task<IActionResult> BuscarProdutoPorId(int id)
        {
            var produto = await _service.BuscarProdutosPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPut("produtos/{id:int}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produtoAtualizado)

        {
            var produto = await _service.EditarProdutoAsync(id, produtoAtualizado);
            return Ok("Atualizado com sucesso !");
        }

        [HttpDelete("produtos/{id:int}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var delproduto = await _service.DeletarProdutoAsync(id);
            if (!delproduto) return NotFound();

            return Ok("Removido com sucesso !");
        }

    }
}