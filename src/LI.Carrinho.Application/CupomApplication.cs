using AutoMapper;
using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Application.Models;
using LI.Carrinho.Application.Results;
using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.Carrinho.Application
{
    public class CupomApplication : ICupomApplication
    {
        private readonly IMapper _mapper;
        private readonly ICupomRepository _cupomRepository;

        public CupomApplication(IMapper mapper, ICupomRepository cupomRepository)
        {
            _mapper = mapper;
            _cupomRepository = cupomRepository;
        }

        public async Task<Result<List<CupomModel>>> ObterCupons()
        {
            var cupons = await _cupomRepository.ObterTodos();
            return Result<List<CupomModel>>.Ok(_mapper.Map<List<CupomModel>>(cupons));
        }

        public async Task<Result<CupomModel>> ObterCupomPeloId(Guid id)
        {
            var cupom = await _cupomRepository.ObterPorId(id);
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(cupom));
        }

        public async Task<Result<CupomModel>> AtualizarCupom(CupomModel cupomModel)
        {
            var cupom = _mapper.Map<Cupom>(cupomModel);

            var cupomAtualizado = await _cupomRepository.AtualizarInformacoesCupom(cupom);
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(cupomAtualizado));
        }

        public async Task<Result<CupomModel>> CadastrarCupom(CupomModel cupomModel)
        {
            var cupom = await _cupomRepository.Adicionar(_mapper.Map<Cupom>(cupomModel));
            return Result<CupomModel>.Ok(_mapper.Map<CupomModel>(cupom));
        }

        public async Task<Result<string>> RemoverCupom(Guid id)
        {
            await _cupomRepository.Remover(id);
            return Result<string>.Ok("Cupom removido.");
        }
    }
}
