using System;
using System.Collections.Generic;

namespace LI.Carrinho.Application.Models
{
    public class CarrinhoModel
    {
        /// <summary>
        /// Subtotal dos itens no carrinho
        /// </summary>
        public decimal VlTotal { get; set; }
        /// <summary>
        /// Lista de itens no carrinho
        /// </summary>
        public List<ItemCarrinhoModel> ItemCarrinhos { get; set; }
        /// <summary>
        /// ID do cliente
        /// </summary>
        public Guid IdCliente { get; set; }
    }
}
