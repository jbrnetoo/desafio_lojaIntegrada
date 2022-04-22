using LI.Carrinho.Domain.Interfaces.UnitOfWork;
using LI.Carrinho.Infrastructure.Context;
using System;

namespace LI.Carrinho.Infrastructure.UnitOfWork
{
    public class UnitOfWorkBase : IUnitOfWorkBase
    {
        private readonly CarrinhoContext context;
        private bool disposed = false;

        public UnitOfWorkBase(CarrinhoContext context) => this.context = context;

        public int Save() => context != null ? context.SaveChanges() : 0;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing && context != null)
                context.Dispose();
            disposed = true;
        }
    }
}
