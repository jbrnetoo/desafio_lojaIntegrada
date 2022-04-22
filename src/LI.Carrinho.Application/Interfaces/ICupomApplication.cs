using LI.Carrinho.Application.Models;
using LI.Carrinho.Application.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.Carrinho.Application.Interfaces
{
    public interface ICupomApplication
    {
        Task<Result<string>> RemoverCupom(Guid id);
        Task<Result<List<CupomModel>>> ObterCupons();
        Task<Result<CupomModel>> ObterCupomPeloId(Guid id);
        Task<Result<CupomModel>> CadastrarCupom(CupomModel cupomModel);
        Task<Result<CupomModel>> AtualizarCupom(CupomModel cupomModel);
    }
}
