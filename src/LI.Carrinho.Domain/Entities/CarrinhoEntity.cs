using System;
using System.Collections.Generic;
using System.Linq;

namespace LI.Carrinho.Domain.Entities
{
    public class CarrinhoEntity : Entity
    {
        public CarrinhoEntity()
        {
            if (ItemCarrinhos == null || !ItemCarrinhos.Any())
                ItemCarrinhos = new List<ItemCarrinho>();
        }

        public decimal VlTotal { get; set; }
        public ICollection<ItemCarrinho> ItemCarrinhos { get; set; }
        public Guid IdCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
