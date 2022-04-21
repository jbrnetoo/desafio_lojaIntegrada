using FluentValidation;
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

    public class ProdutoModelValidator : AbstractValidator<ProdutoModel>
    {
        public ProdutoModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio")
                .Length(1, 200).WithMessage("Tamanho ({TotalLength}) do {PropertyName} inválido");

            RuleFor(x => x.Descricao)
               .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio")
               .Length(1, 200).WithMessage("Tamanho ({TotalLength}) do {PropertyName} inválido");

            RuleFor(x => x.Peso)
                .LessThanOrEqualTo(2000).WithMessage("O peso não pode ser maior que 2000");
        }
    }
}
