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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _service;
        public ClientesController(IClienteRepository service)
        {
            _service = service;
        }



        [HttpPost("clientes")]
        public async Task<IActionResult> AdicionarClientes([FromBody] Cliente clientes)
        {
            var resultado = await _service.AddClienteAsync(clientes);
            return Ok(resultado);
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> ListarClientes()
        {
            var clientes = await _service.ListarClienteAsync();
            return Ok(clientes);
        }

        [HttpGet("clientes/{id:int}")]
        public async Task<IActionResult> GetIdClientes(int id)
        {
            var cliente = await _service.BuscarClientePorIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPut("clientes/{id:int}")]
        public async Task<IActionResult> AtualizarClientes(int id, [FromBody] Cliente clienteupdate)
        {
            var resultado = await _service.EditarClienteAsync(id, clienteupdate);
            if (!resultado) return NotFound();

            return Ok();
        }

        [HttpDelete("clientes/{id:int}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            var delclientes = await _service.DeletarClientePorIdAsync(id);
            if (!delclientes) return NotFound();

            return Ok(new { Mensagem = "Cliente removido com sucesso !! " });
        }




    }

}