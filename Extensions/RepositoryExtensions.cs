
using FarmaciaSOFT.Interfaces;
using FarmaciaSOFT.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FarmaciaAPI.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}