using System;

namespace LI.Carrinho.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DtNascimento { get; set; }
        public string Email { get; set; }
    }
}
