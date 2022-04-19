using System.Collections.Generic;

namespace LI.Carrinho.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Peso { get; set; }
        public decimal Preco { get; set; }
        public IEnumerable<ItemCarrinho> ItemCarrinhos { get; set; }
    }
}
