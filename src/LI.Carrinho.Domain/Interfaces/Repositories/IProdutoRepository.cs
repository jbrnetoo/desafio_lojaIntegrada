using LI.Carrinho.Domain.Entities;
using System.Threading.Tasks;

namespace LI.Carrinho.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> AtualizarInformacoesProduto(Produto produto);
    }

}
