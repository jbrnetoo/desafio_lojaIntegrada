using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces.Repositories;
using LI.Carrinho.Infrastructure.Context;
using System.Threading.Tasks;

namespace LI.Carrinho.Infrastructure.Repository
{
    public class CupomRepository : Repository<Cupom>, ICupomRepository
    {
        public CupomRepository(CarrinhoContext context) : base(context) { }

        public async Task<Cupom> AtualizarInformacoesCupom(Cupom cupom)
        {
            var cupomRef = await ObterPorId(cupom.Id);
            cupomRef.Descricao = cupom.Descricao;
            cupomRef.ValorCupom = cupom.ValorCupom;
            await Atualizar(cupomRef);

            return cupomRef;
        }
    }
}
