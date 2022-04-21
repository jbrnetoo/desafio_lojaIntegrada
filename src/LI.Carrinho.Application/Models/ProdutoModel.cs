using System;
using System.Collections.Generic;

namespace LI.Carrinho.Application.Models
{
    public class ProdutoModel
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Peso { get; set; }
        public decimal Preco { get; set; }
        public List<ItemCarrinhoModel> ItemCarrinhos { get; set; }
    }
}
