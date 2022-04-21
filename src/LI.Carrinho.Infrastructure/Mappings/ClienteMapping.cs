using LI.Carrinho.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LI.Carrinho.Infrastructure.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(x => x.DtNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Email)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder.HasOne(x => x.Carrinho)
                .WithOne(x => x.Cliente)
                .HasForeignKey<CarrinhoEntity>(x => x.IdCliente);

            builder.ToTable("TB_CLIENTE");
        }
    }
}
