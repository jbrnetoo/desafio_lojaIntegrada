using System;

namespace LI.Carrinho.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkBase : IDisposable
    {
        int Save();
    }
}
