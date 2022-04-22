using System;

namespace LI.Carrinho.Application.Models
{
    public class ItemCarrinhoModel
    {
        /// <summary>
        /// ID do produto
        /// </summary>
        public Guid IdProduto { get; set; }
        /// <summary>
        /// ID do carrinho
        /// </summary>
        public Guid IdCarrinho { get; set; }
        /// <summary>
        /// Quantidade de itens no carrinho
        /// </summary>
        public int Quantidade { get; set; }
        /// <summary>
        /// Model de Produto
        /// </summary>
        public ProdutoModel Produto { get; set; }
        /// <summary>
        /// Model de Carrinho
        /// </summary>
        public CarrinhoModel Carrinho { get; set; }
    }
}
