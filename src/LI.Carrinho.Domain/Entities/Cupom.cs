using System.Collections.Generic;

namespace LI.Carrinho.Domain.Entities
{
    public class Cupom : Entity
    {
        public string Descricao { get; set; }
        public decimal ValorCupom { get; set; }
        public ICollection<CarrinhoEntity> Carrinhos { get; set; }
    }
}
