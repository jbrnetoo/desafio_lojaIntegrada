using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces.Repositories;
using LI.Carrinho.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
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
            itemCarrinho.Quantidade = quantidade;
            _dbSet.Update(itemCarrinho);
            return await _context.SaveChangesAsync();
        }
    }
}
