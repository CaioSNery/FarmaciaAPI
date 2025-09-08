
using AutoMapper;
using FarmaciaSOFT.Dtos;
using FarmaciaSOFT.Models;


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