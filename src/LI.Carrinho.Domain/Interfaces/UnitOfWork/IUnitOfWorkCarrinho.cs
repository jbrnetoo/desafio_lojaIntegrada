using LI.Carrinho.Domain.Interfaces.Repositories;

namespace LI.Carrinho.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkCarrinho : IUnitOfWorkBase
    {
        ICarrinhoRepository CarrinhoRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IItemCarrinhoRepository ItemCarrinhoRepository { get; }
        ICupomRepository CupomRepository { get; }
    }
}
