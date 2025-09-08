using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Data;
using FarmaciaSOFT.Interfaces;
using FarmaciaSOFT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaSOFT.Controllers
{
    [ApiController]
    [Route("v1")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaRepository _vendaservice;
        public VendasController(IVendaRepository vendaservice)
        {
            _vendaservice = vendaservice;
        }

        [HttpPost("vendas")]
        public async Task<ActionResult> RealizarVenda([FromBody] VendasDTO vendasDTO)
        {
            var resultado = await _vendaservice.RealizarVendaAsync(vendasDTO);
            if (resultado is string erro)
            {
                if (erro.Contains("não encontrado")) return NotFound(erro);

                return BadRequest(erro);
            }
            return Ok(resultado);
        }


        [HttpGet("vendas")]
        public async Task<ActionResult<IEnumerable<Venda>>> ObterVendas()
        {
            var vendas = await _vendaservice.ListarVendasAsync();
            return Ok(vendas);
        }


        [HttpGet("vendas/{id:int}")]
        public async Task<ActionResult<Venda>> GetIdVendas(int id)
        {
            var venda = await _vendaservice.BuscarVendasPorIdAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);



        }







    }
}