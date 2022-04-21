using FluentValidation;
using System;

namespace LI.Carrinho.Application.Models
{
    public class ClienteModel
    {
        /// <summary>
        /// ID do Cliente
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Documento do cliente
        /// </summary>
        public string Cpf { get; set; }
        /// <summary>
        /// Data de nascimento do cliente
        /// </summary>
        public DateTime DtNascimento { get; set; }
        /// <summary>
        /// E-mail do cliente
        /// </summary>
        public string Email { get; set; }
    }

    public class ClienteModelValidator : AbstractValidator<ClienteModel>
    {
        public ClienteModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio")
                .Length(1, 200).WithMessage("Tamanho ({TotalLength}) do {PropertyName} inválido");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio")
                .Length(1, 11).WithMessage("Tamanho ({TotalLength}) do {PropertyName} inválido");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("O Valor informado: ({PropertyValue}) não é um Email válido")
                .Length(1, 200).WithMessage("Tamanho ({TotalLength}) do {PropertyName} inválido");
        }
    }
}
