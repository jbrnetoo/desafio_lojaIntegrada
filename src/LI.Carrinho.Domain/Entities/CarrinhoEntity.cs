using System;
using System.Collections.Generic;

namespace LI.Carrinho.Domain.Entities
{
    public class CarrinhoEntity : Entity
    {
        public decimal VlTotal { get; set; }
        public ICollection<ItemCarrinho> ItemCarrinhos { get; set; }
        public Guid IdCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
