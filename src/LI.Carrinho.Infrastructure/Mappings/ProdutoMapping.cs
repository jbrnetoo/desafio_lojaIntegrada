using LI.Carrinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LI.Carrinho.Infrastructure.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(f => f.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(f => f.Descricao)
              .IsRequired()
              .HasColumnType("varchar(300)");

            builder.Property(f => f.Peso)
               .IsRequired()
               .HasColumnType("int");

            builder.Property(f => f.Preco)
               .IsRequired()
               .HasColumnType("decimal(10,2)");

            builder.ToTable("TB_PRODUTOS");
        }
    }
}
