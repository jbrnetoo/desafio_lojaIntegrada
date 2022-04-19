using System;
using System.Collections.Generic;

namespace LI.Carrinho.Domain.Entities
{
    public class CarrinhoEntity : Entity
    {
        public Guid IdCliente { get; set; }
        public decimal VlTotal { get; set; }
        public IEnumerable<ItemCarrinho> ItemCarrinhos { get; set; }
    }
}
