using System;

namespace LI.Carrinho.Application.Models
{
    public class CupomModel
    {
        /// <summary>
        /// Código do cupom
        /// </summary>
        public Guid Codigo { get; set; }
        /// <summary>
        /// Descrição do cupom
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Valor do cupom
        /// </summary>
        public decimal ValorCupom { get; set; }
    }
}
