using LI.Carrinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LI.Carrinho.Infrastructure.Mappings
{
    public class CarrinhoMapping : IEntityTypeConfiguration<CarrinhoEntity>
    {
        public void Configure(EntityTypeBuilder<CarrinhoEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.VlTotal)
             .IsRequired()
             .HasColumnType("decimal(10,2)");

            builder.HasOne(c => c.Cupom)
                .WithMany(c => c.Carrinhos)
                .HasForeignKey(c => c.IdCupom)
                .IsRequired(false);

            builder.ToTable("TB_CARRINHO");
        }
    }
}
