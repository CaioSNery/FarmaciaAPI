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
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IVendaService _vendaservice;
        public VendasController(IVendaService vendaservice)
        {
            _vendaservice = vendaservice;
        }

        [HttpPost]
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

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> ObterVendas()
        {
            var vendas = await _vendaservice.ListarVendasAsync();
            return Ok(vendas);
        }


        [HttpGet("{id}")]
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