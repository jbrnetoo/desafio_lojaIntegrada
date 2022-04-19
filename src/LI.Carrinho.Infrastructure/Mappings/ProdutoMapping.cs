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

            builder.Property(x => x.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(x => x.Descricao)
              .IsRequired()
              .HasColumnType("varchar(300)");

            builder.Property(x => x.Peso)
               .IsRequired()
               .HasColumnType("int");

            builder.Property(x => x.Preco)
               .IsRequired()
               .HasColumnType("decimal(10,2)");

            builder.ToTable("TB_PRODUTOS");
        }
    }
}
