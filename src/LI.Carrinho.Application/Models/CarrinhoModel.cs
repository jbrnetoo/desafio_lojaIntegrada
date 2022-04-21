using System;
using System.Collections.Generic;

namespace LI.Carrinho.Application.Models
{
    public class CarrinhoModel
    {
        public decimal VlTotal { get; set; }
        public List<ItemCarrinhoModel> ItemCarrinhos { get; set; }
        public Guid IdCliente { get; set; }
    }
}
