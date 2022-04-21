using LI.Carrinho.Domain.Entities;
using System.Threading.Tasks;

namespace LI.Carrinho.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterClientePorDocumento(string documento);
        Task<Cliente> AtualizarInformacoes(Cliente cliente);
    }
}
