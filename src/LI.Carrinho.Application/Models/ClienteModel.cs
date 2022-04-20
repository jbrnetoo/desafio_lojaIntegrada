using System;

namespace LI.Carrinho.Application.Models
{
    public class ClienteModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Email { get; set; }
        public CarrinhoModel Carrinho { get; set; }
    }
}
