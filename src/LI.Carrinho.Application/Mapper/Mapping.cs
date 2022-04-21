using AutoMapper;
using LI.Carrinho.Application.Models;
using LI.Carrinho.Domain.Entities;

namespace LI.Carrinho.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProdutoModel, Produto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Codigo))
                .ReverseMap();
            CreateMap<ClienteModel, Cliente>().ReverseMap();
            CreateMap<CarrinhoModel, CarrinhoEntity>().ReverseMap();
            CreateMap<ItemCarrinhoModel, ItemCarrinho>().ReverseMap();
        }
    }
}
