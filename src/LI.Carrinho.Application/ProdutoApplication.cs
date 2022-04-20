using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Application.Models;
using LI.Carrinho.Application.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.Carrinho.Application
{
    public class ProdutoApplication : IProdutoApplication
    {
        public async Task<Result<ProdutoModel>> AtualizarProduto(ProdutoModel produto)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<ProdutoModel>> ObterProdutoPeloId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<ProdutoModel>>> ObterProdutos()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<ProdutoModel>> RemoverProduto(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
