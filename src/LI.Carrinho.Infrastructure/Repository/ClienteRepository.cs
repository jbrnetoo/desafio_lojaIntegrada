using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces.Repositories;
using LI.Carrinho.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LI.Carrinho.Infrastructure.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CarrinhoContext context) : base(context) { }

        public async Task<Cliente> AtualizarInformacoes(Cliente cliente)
        {
            var clienteRef = await ObterClientePorDocumento(cliente.Cpf);
            clienteRef.Nome = cliente.Nome;
            clienteRef.Email = cliente.Email;
            clienteRef.Cpf = cliente.Cpf;
            clienteRef.DtNascimento = cliente.DtNascimento;
            await Atualizar(clienteRef);
            return clienteRef;
        }

        public Task<Cliente> ObterClientePorDocumento(string documento) => Task.FromResult(_context.Clientes
                .Include(x => x.Carrinho)
                .ThenInclude(x => x.ItemCarrinhos)
                .ThenInclude(x => x.Produto)
                .FirstOrDefault(c => c.Cpf.Equals(documento)));

    }
}
