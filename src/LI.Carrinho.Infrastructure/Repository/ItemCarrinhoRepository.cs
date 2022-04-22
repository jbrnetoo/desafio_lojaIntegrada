using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces.Repositories;
using LI.Carrinho.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LI.Carrinho.Infrastructure.Repository
{
    public class ItemCarrinhoRepository : IItemCarrinhoRepository
    {
        private readonly CarrinhoContext _context;
        private readonly DbSet<ItemCarrinho> _dbSet;

        public ItemCarrinhoRepository(CarrinhoContext context)
        {
            _context = context;
            _dbSet = context.Set<ItemCarrinho>();
        }

        public async Task<int> AtualizarQuantidade(Guid idProduto, Guid idCarrinho, int quantidade)
        {
            var itemCarrinho = await _dbSet.FindAsync(idProduto, idCarrinho);
            itemCarrinho.Quantidade += quantidade;
            _dbSet.Update(itemCarrinho);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoverItemCarrinho(Guid idProduto, Guid idCarrinho)
        {
            var itemCarrinho = await _dbSet.FindAsync(idProduto, idCarrinho);
            _dbSet.Remove(itemCarrinho);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> LimparCarrinho(Guid idCarrinho)
        {
            var itensCarrinho = _dbSet.Where(x => x.IdCarrinho == idCarrinho);
            _dbSet.RemoveRange(itensCarrinho);
            return await _context.SaveChangesAsync();
        }
    }
}
