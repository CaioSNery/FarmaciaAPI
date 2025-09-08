using System;
using System.Threading.Tasks;
using FarmaciaSOFT.Data;
using FarmaciaSOFT.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FarmaciaSOFT.Services;
using FarmaciaSOFT.Interfaces;
using AutoMapper;
using Moq; // Add this if VendaService is in Services namespace


namespace FarmaciaAPI.Tests;

public class VendaRepositoryTests
{
    private readonly DbContextOptions<AppDbContext> _dbOptions;

    public VendaRepositoryTests()
    {
        _dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "FarmaciaTestDb")
            .Options;
    }

    [Fact]
    public async Task RealizarVendaAsync_DeveAplicar10PorcentoDeDesconto_QuandoClienteForValido()
    {
        // Arrange: Cria contexto em memória
        using var context = new AppDbContext(_dbOptions);

        var cliente = new Cliente
        {
            Id = 1,
            Nome = "João",
            Cpf = "12345678900",
            Telefone = "11999999999",
            Nascimento = new DateTime(1990, 1, 1)
        };

        var produto = new Produto
        {
            Id = 1,
            Nome = "Dipirona",
            PrecoVenda = 100m,
            Estoque = 10,
            Tipo = "Medicamento"
        };

        context.Clientes.Add(cliente);
        context.Produtos.Add(produto);
        await context.SaveChangesAsync();

        // Mocks
        var mockSmsService = new Mock<ISMSService>();
        var mockMapper = new Mock<IMapper>();

        // Serviço a ser testado
        var service = new VendaRepository(context, mockSmsService.Object, mockMapper.Object);

        var vendaDto = new VendasDTO
        {
            ClienteId = cliente.Id,
            ProdutoId = produto.Id,
            Quantidade = 1
        };

        // Act
        var resultado = await service.RealizarVendaAsync(vendaDto);

        dynamic retorno = resultado;

        // Assert
        Assert.Equal(90m, retorno.ValorUnitarioComDesconto); // 10% de desconto
        Assert.Equal(90m, retorno.Total);
        Assert.Equal("João", retorno.Cliente);
        Assert.Equal("Dipirona", retorno.Produto);

        // Verifica se estoque foi atualizado
        var produtoAtualizado = await context.Produtos.FindAsync(produto.Id);
        Assert.Equal(9, produtoAtualizado.Estoque);
    }
}


