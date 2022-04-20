using LI.Carrinho.Application.Models;
using LI.Carrinho.Application.Results;
using System;
using System.Threading.Tasks;

namespace LI.Carrinho.Application.Interfaces
{
    public interface ICarrinhoApplication
    {
        Task<Result<ProdutoModel>> AdicionarItem(Guid idProduto, string documento);
        Task<Result<string>> RemoverItem(Guid id);
        Task<Result<ProdutoModel>> AtualizarQuantidade(Guid id, int quantidade);
        Task<Result<string>> LimparCarrinho();
        Task<Result<string>> AdicionarCupomDesconto();
        Task<Result<string>> GerarTotaisSubtotais();
        Task<Result<CarrinhoModel>> ObterCarrinho(string documento);
    }
}
