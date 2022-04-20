using AutoMapper;
using LI.Carrinho.Application.Models;
using LI.Carrinho.Domain.Entities;

namespace LI.Carrinho.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ClienteModel, Cliente>().ReverseMap();
            CreateMap<ProdutoModel, Produto>().ReverseMap();
            CreateMap<CarrinhoModel, CarrinhoEntity>().ReverseMap();
            CreateMap<ItemCarrinhoModel, ItemCarrinho>().ReverseMap();
        }
    }
}
