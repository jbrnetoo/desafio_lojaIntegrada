using System;
using System.Threading.Tasks;

namespace LI.Carrinho.Domain.Interfaces.Repositories
{
    public interface IItemCarrinhoRepository
    {
        Task<int> AtualizarQuantidade(Guid idProduto, Guid idCarrinho, int quantidade);
        Task<int> RemoverItemCarrinho(Guid idProduto, Guid idCarrinho);
        Task<int> LimparCarrinho(Guid idCarrinho);
    }
}
