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

        #region Obter Carrinho
        public async Task<Result<CarrinhoModel>> ObterCarrinho(string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var carrinho = await _unitOfWorkCarrinho.CarrinhoRepository.ObterCarrinho(documento);

            if (carrinho != null)
                return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(carrinho));
            else
                return Result<CarrinhoModel>.Error("Nenhum carrinho foi encontrado para este cliente.", (int)HttpStatusCode.NotFound);

        }
        #endregion

        #region Adicionar Item
        public async Task<Result<CarrinhoModel>> AdicionarItem(Guid idProduto, string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);

            if (cliente != null)
            {
                var itensDic = cliente.Carrinho.ItemCarrinhos.ToDictionary(x => x.IdProduto);

                if (itensDic.ContainsKey(idProduto))
                {
                    var item = itensDic[idProduto];
                    item.Quantidade++;
                }
                else
                {
                    var produto = await _unitOfWorkCarrinho.ProdutoRepository.ObterPorId(idProduto);

                    var itemCarrinho = new ItemCarrinho()
                    {
                        IdCarrinho = cliente.Carrinho.Id,
                        IdProduto = idProduto,
                        Quantidade = 1,
                        Produto = produto
                    };

                    cliente.Carrinho.ItemCarrinhos.Add(itemCarrinho);
                }

                int result = RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(cliente.Carrinho));
            }

            return Result<CarrinhoModel>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region Remover Item
        public async Task<Result<string>> RemoverItem(Guid idProduto, string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<string>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);

            if (cliente != null)
            {
                var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.RemoverItemCarrinho(idProduto, cliente.Carrinho.Id);

                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<string>.Ok("Item removido do carrinho.");
            }

            return Result<string>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region Atualizar Quantidade
        public async Task<Result<CarrinhoModel>> AtualizarQuantidade(Guid idProduto, string documento, int quantidade)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);

            if (cliente != null)
            {
                var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.AtualizarQuantidade(idProduto, cliente.Carrinho.Id, quantidade);

                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(cliente.Carrinho));
            }

            return Result<CarrinhoModel>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region Limpar Carrinho
        public async Task<Result<string>> LimparCarrinho(string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<string>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);

            if (cliente != null)
            {
                var result = await _unitOfWorkCarrinho.ItemCarrinhoRepository.LimparCarrinho(cliente.Carrinho.Id);

                RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<string>.Ok("Carrinho foi limpo.");
            }

            return Result<string>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region Adicionar Cupom Desconto
        public async Task<Result<CarrinhoModel>> AdicionarCupomDesconto(Guid idCupom, string documento)
        {
            if (!CpfCnpjUtils.IsCpf(documento))
                return Result<CarrinhoModel>.Error("O documento informado não é um CPF válido.", (int)HttpStatusCode.BadRequest);

            var cliente = await _unitOfWorkCarrinho.ClienteRepository.ObterClientePorDocumento(documento);

            if (cliente != null)
            {
                var cupom = await _unitOfWorkCarrinho.CupomRepository.ObterPorId(idCupom);
                cliente.Carrinho.IdCupom = idCupom;
                cliente.Carrinho.Cupom = cupom;

                var result = RecalcularValorTotal(cliente);
                if (result > 0)
                    return Result<CarrinhoModel>.Ok(_mapper.Map<CarrinhoModel>(cliente.Carrinho));
                else
                    return Result<CarrinhoModel>.Error("Cupom já adicionado.", (int)HttpStatusCode.BadRequest);
            }

            return Result<CarrinhoModel>.Error("Cliente não foi encontrado.", (int)HttpStatusCode.NotFound);
        }
        #endregion

        #region Recalcular Valor Total
        private int RecalcularValorTotal(Cliente cliente)
        {
            if (cliente.Carrinho.Cupom != null)
                cliente.Carrinho.VlTotal = (cliente.Carrinho.ItemCarrinhos.Sum(x => x.Produto.Preco * x.Quantidade)) - cliente.Carrinho.Cupom.ValorCupom;
            else
                cliente.Carrinho.VlTotal = (cliente.Carrinho.ItemCarrinhos.Sum(x => x.Produto.Preco * x.Quantidade));

            return _unitOfWorkCarrinho.Save();
        }
        #endregion
    }
}
