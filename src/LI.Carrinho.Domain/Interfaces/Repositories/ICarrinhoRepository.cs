using LI.Carrinho.Domain.Entities;
using System.Threading.Tasks;

namespace LI.Carrinho.Domain.Interfaces.Repositories
{
    public interface ICarrinhoRepository : IRepository<CarrinhoEntity>
    {
        Task<CarrinhoEntity> ObterCarrinho(string documento);
    }
}
