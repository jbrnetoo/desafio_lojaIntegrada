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
}
