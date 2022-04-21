using System;

namespace LI.Carrinho.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
