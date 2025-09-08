
using System;
using FarmaciaSOFT.Interfaces;
using FarmaciaSOFT.Services;
using Microsoft.Extensions.DependencyInjection;


namespace FarmaciaAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISMSService, SMSService>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }


    }
}