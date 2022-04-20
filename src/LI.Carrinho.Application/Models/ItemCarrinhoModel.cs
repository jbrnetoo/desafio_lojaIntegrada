using System;

namespace LI.Carrinho.Application.Models
{
    public class ItemCarrinhoModel
    {
        public Guid IdProduto { get; set; }
        public Guid IdCarrinho { get; set; }
        public int Quantidade { get; set; }
        public ProdutoModel Produto { get; set; }
        public CarrinhoModel Carrinho { get; set; }
    }
}
