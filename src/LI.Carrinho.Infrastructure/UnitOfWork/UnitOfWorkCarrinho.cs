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

        public UnitOfWorkCarrinho(CarrinhoContext context) : base(context) => _context = context;
        public IClienteRepository ClienteRepository => _clienteRepository ?? (_clienteRepository = new ClienteRepository(_context));
        public IProdutoRepository ProdutoRepository => _produtoRepository ?? (_produtoRepository = new ProdutoRepository(_context));
        public ICarrinhoRepository CarrinhoRepository => _carrinhoRepository ?? (_carrinhoRepository = new CarrinhoRepository(_context));
    }
}
