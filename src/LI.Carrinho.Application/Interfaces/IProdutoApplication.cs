using LI.Carrinho.Application.Models;
using LI.Carrinho.Application.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.Carrinho.Application.Interfaces
{
    public interface IProdutoApplication
    {
        Task<Result<string>> RemoverProduto(Guid id);
        Task<Result<List<ProdutoModel>>> ObterProdutos();
        Task<Result<ProdutoModel>> ObterProdutoPeloId(Guid id);
        Task<Result<ProdutoModel>> CadastrarProduto(ProdutoModel produtoModel);
        Task<Result<ProdutoModel>> AtualizarProduto(ProdutoModel produtoModel);
    }
}
