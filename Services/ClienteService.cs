using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaciaSOFT.Data;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Interfaces;
using FarmaciaSOFT.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Twilio.TwiML.Voice;

namespace FarmaciaSOFT.Services
{
    public class ClienteService : IClienteService
    {

        private readonly AppDbContext _context;
        private readonly ISMSService _smsService;
        public ClienteService(AppDbContext context, ISMSService smsService)
        {
            _context = context;
            _smsService = smsService;
        }
        public async Task<object> AddClienteAsync(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();

            string msg = $"Olá {clientes.Nome}, seu cadastro foi registrado com sucesso,aproveite a promoção de 10% de desconto!";
            await _smsService.EnviarSMSAsync(clientes.Telefone, msg);

            return clientes;
        }

        public async Task<object> BuscarClientePorIdAsync(int id)
        {
            var cliente = await _context.Clientes
            .Where(p => p.Id == id)
            .Select(p => new ClienteDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Cpf = p.Cpf
            })
            .FirstOrDefaultAsync();

            if (cliente == null) return false;

            return cliente;
            
        }

        public async Task<bool> DeletarClientePorIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditarClienteAsync(int id, Clientes clienteupdate)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            cliente.Nome = clienteupdate.Nome;
            cliente.Cpf = clienteupdate.Cpf;
            cliente.Nascimento = clienteupdate.Nascimento;

            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ClienteDTO>> ListarClienteAsync()
        {
            return await _context.Clientes.Select(p=>new ClienteDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Cpf=p.Cpf
            }).ToListAsync();
        }
    }
}