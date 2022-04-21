using LI.Carrinho.Domain.Interfaces.Repositories;
using LI.Carrinho.Domain.Interfaces.UnitOfWork;
using LI.Carrinho.Infrastructure.Context;
using LI.Carrinho.Infrastructure.Repository;

namespace LI.Carrinho.Infrastructure.UnitOfWork
{
    public class UnitOfWorkCarrinho : UnitOfWorkBase, IUnitOfWorkCarrinho
    {
        private readonly CarrinhoContext _context;

        private IClienteRepository _clienteRepository;
        private IProdutoRepository _produtoRepository;
        private ICarrinhoRepository _carrinhoRepository;
        private IItemCarrinhoRepository _itemCarrinhoRepository;
        private ICupomRepository _cupomRepository;

        public UnitOfWorkCarrinho(CarrinhoContext context) : base(context) => _context = context;
        public IClienteRepository ClienteRepository => _clienteRepository ??= new ClienteRepository(_context);
        public IProdutoRepository ProdutoRepository => _produtoRepository ??= new ProdutoRepository(_context);
        public ICarrinhoRepository CarrinhoRepository => _carrinhoRepository ??= new CarrinhoRepository(_context);
        public IItemCarrinhoRepository ItemCarrinhoRepository => _itemCarrinhoRepository ??= new ItemCarrinhoRepository(_context);
        public ICupomRepository CupomRepository => _cupomRepository ??= new CupomRepository(_context);
    }
}
