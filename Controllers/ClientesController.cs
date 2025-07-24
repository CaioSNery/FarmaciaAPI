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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClientesController(IClienteService service)
        {
            _service = service;
        }



        [HttpPost]
        public async Task<IActionResult> AdicionarClientes([FromBody] Cliente clientes)
        {
            var resultado = await _service.AddClienteAsync(clientes);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            var clientes = await _service.ListarClienteAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdClientes(int id)
        {
            var cliente = await _service.BuscarClientePorIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarClientes(int id, [FromBody] Cliente clienteupdate)
        {
            var resultado = await _service.EditarClienteAsync(id, clienteupdate);
            if (!resultado) return NotFound();

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            var delclientes = await _service.DeletarClientePorIdAsync(id);
            if (!delclientes)return NotFound();
            
            return Ok(new { Mensagem = "Cliente removido com sucesso !! " });
        }




    }

}