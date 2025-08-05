using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Models;
using Twilio.Rest.Sync.V1.Service.SyncMap;

namespace FarmaciaAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();

            CreateMap<Venda, VendasDTO>().ReverseMap();

            CreateMap<Produto, ProdutoDTO>().ReverseMap();

        }
    }
}