using LI.Carrinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LI.Carrinho.Infrastructure.Mappings
{
    public class ItemCarrinhoMapping : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.HasKey(ic => new { ic.IdProduto, ic.IdCarrinho });

            builder.Property(ic => ic.Quantidade)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(ic => ic.Produto)
                .WithMany(p => p.ItemCarrinhos)
                .HasForeignKey(ic => ic.IdProduto);

            builder.HasOne(ic => ic.Carrinho)
               .WithMany(p => p.ItemCarrinhos)
               .HasForeignKey(ic => ic.IdCarrinho);

            builder.ToTable("TB_ITEM_CARRINHO");
        }
    }
}
