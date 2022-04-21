using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces.Repositories;
using LI.Carrinho.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LI.Carrinho.Infrastructure.Repository
{
    public class CarrinhoRepository : Repository<CarrinhoEntity>, ICarrinhoRepository
    {
        public CarrinhoRepository(CarrinhoContext context) : base(context) { }

        public async Task<CarrinhoEntity> ObterCarrinho(string documento) => await Task.FromResult(_context.Carrinhos
             .Include(x => x.Cliente)
             .Include(x => x.ItemCarrinhos)
             .ThenInclude(x => x.Produto)
             .FirstOrDefault(c => c.Cliente.Cpf.Equals(documento)));
    }
}
