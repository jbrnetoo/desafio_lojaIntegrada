using LI.Carrinho.Domain.Entities;
using System.Threading.Tasks;

namespace LI.Carrinho.Domain.Interfaces.Repositories
{
    public interface ICupomRepository : IRepository<Cupom>
    {
        Task<Cupom> AtualizarInformacoesCupom(Cupom cupom);
    }
}
