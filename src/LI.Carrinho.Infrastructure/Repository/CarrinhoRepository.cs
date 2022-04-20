using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces;
using LI.Carrinho.Infrastructure.Context;

namespace LI.Carrinho.Infrastructure.Repository
{
    public class CarrinhoRepository : Repository<CarrinhoEntity>, ICarrinhoRepository
    {
        public CarrinhoRepository(CarrinhoContext context) : base(context) { }

    }
}
