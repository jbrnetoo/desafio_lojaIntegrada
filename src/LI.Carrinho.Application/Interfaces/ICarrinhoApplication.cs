using LI.Carrinho.Application.Results;
using System.Threading.Tasks;

namespace LI.Carrinho.Application.Interfaces
{
    public interface ICarrinhoApplication
    {
        Task<Result<string>> AdicionarItem();
        Task<Result<string>> RemoverItem();
        Task<Result<string>> AtualizarQuantidaded();
        Task<Result<string>> LimparCarrinho();
        Task<Result<string>> AdicionarCupomDesconto();
        Task<Result<string>> GerarTotaisSubtotais();
        Task<Result<string>> ObterCarrinho();
    }
}
