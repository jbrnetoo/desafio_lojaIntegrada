using System;

namespace LI.Carrinho.Application.Models
{
    public class ProdutoModel
    {
        /// <summary>
        /// Código do produto
        /// </summary>
        public Guid Codigo { get; set; }
        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Peso do produto
        /// </summary>
        public int Peso { get; set; }
        /// <summary>
        /// Preço do produto
        /// </summary>
        public decimal Preco { get; set; }
    }
}
