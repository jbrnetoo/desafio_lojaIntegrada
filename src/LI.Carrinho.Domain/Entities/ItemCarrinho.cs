using System;

namespace LI.Carrinho.Domain.Entities
{
    public class ItemCarrinho
    {
        public Guid IdProduto { get; set; }
        public Guid IdCarrinho { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public CarrinhoEntity Carrinho { get; set; }
    }
}
