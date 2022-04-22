using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces.Repositories;
using LI.Carrinho.Infrastructure.Context;
using System.Threading.Tasks;

namespace LI.Carrinho.Infrastructure.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CarrinhoContext context) : base(context) { }

        public async Task<Produto> AtualizarInformacoesProduto(Produto produto)
        {
            var produtoRef = await ObterPorId(produto.Id);
            produtoRef.Nome = produto.Nome;
            produtoRef.Descricao = produto.Descricao;
            produtoRef.Preco = produto.Preco;
            produtoRef.Peso = produto.Peso;
            await Atualizar(produtoRef);

            return produtoRef;
        }
    }
}
