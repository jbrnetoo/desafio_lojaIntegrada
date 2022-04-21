using LI.Carrinho.Application.Models;
using LI.Carrinho.Application.Results;
using System;
using System.Threading.Tasks;

namespace LI.Carrinho.Application.Interfaces
{
    public interface ICarrinhoApplication
    {
        Task<Result<CarrinhoModel>> AdicionarItem(Guid idProduto, string documento);
        Task<Result<string>> RemoverItem(Guid idProduto, string documento);
        Task<Result<CarrinhoModel>> AtualizarQuantidade(Guid idProduto, string documento, int quantidade);
        Task<Result<string>> LimparCarrinho(string documento);
        Task<Result<string>> AdicionarCupomDesconto();
        Task<Result<string>> GerarTotaisSubtotais();
        Task<Result<CarrinhoModel>> ObterCarrinho(string documento);
    }
}
