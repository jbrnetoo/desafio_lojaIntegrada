using AutoMapper;
using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Application.Models;
using LI.Carrinho.Application.Results;
using LI.Carrinho.Domain.Entities;
using LI.Carrinho.Domain.Interfaces.UnitOfWork;
using LI.Carrinho.Domain.ValueObjects;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LI.Carrinho.Application
{
    public class CarrinhoApplication : ICarrinhoApplication
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkCarrinho _unitOfWorkCarrinho;

        public CarrinhoApplication(IMapper mapper, IUnitOfWorkCarrinho unitOfWorkCarrinho)
        {
            _mapper = mapper;
            _unitOfWorkCarrinho = unitOfWorkCarrinho;
        }

        public async Task<Result<CarrinhoModel>> ObterCarrinho(string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var carrinhos = await _unitOfWorkCarrinho.CarrinhoRepository.Buscar(x => x.Cliente.Cpf.Equals(documento));

            if (carrinhos.Any())
                return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(carrinhos.FirstOrDefault()));
            else
                return Result<CarrinhoModel>.Error("Nenhum carrinho foi encontrado para este cliente.", (int)HttpStatusCode.NotFound);

        }

        public async Task<Result<ProdutoModel>> AdicionarItem(Guid idProduto, string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<ProdutoModel>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);

            if (cliente != null)
            {
                var itemCarrinho = new ItemCarrinho()
                {
                    IdCarrinho = cliente.Carrinho.Id,
                    IdProduto = idProduto,
                    Quantidade = 1
                };

                cliente.Carrinho.ItemCarrinhos.Add(itemCarrinho);

                var result = _unitOfWorkCarrinho.Save();

                var produto = await _unitOfWorkCarrinho.ProdutoRepository.ObterPorId(idProduto);

                if (result > 0)
                    return Result<ProdutoModel>.Ok(_mapper.Map<ProdutoModel>(produto));
            }

            return Result<ProdutoModel>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }

        public Task<Result<string>> RemoverItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProdutoModel>> AtualizarQuantidade(Guid id, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> LimparCarrinho()
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> AdicionarCupomDesconto()
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> GerarTotaisSubtotais()
        {
            throw new NotImplementedException();
        }
    }
}
