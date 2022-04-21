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
    public class ProdutoApplication : IProdutoApplication
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoApplication(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }
        public async Task<Result<List<ProdutoModel>>> ObterProdutos()
        {
            var produtos = await _produtoRepository.ObterTodos();
            return Result<List<ProdutoModel>>.Ok(_mapper.Map<List<ProdutoModel>>(produtos));
        }

        public async Task<Result<ProdutoModel>> ObterProdutoPeloId(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);
            return Result<ProdutoModel>.Ok(_mapper.Map<ProdutoModel>(produto));
        }

        public async Task<Result<ProdutoModel>> AtualizarProduto(ProdutoModel produtoModel)
        {
            var produto = _mapper.Map<Produto>(produtoModel);

            await _produtoRepository.AtualizarInformacoesProduto(produto);
            return Result<ProdutoModel>.Ok(produtoModel);
        }

        public async Task<Result<string>> RemoverProduto(Guid id)
        {
            await _produtoRepository.Remover(id);
            return Result<string>.Ok("Produto removido.");
        }

        public async Task<Result<ProdutoModel>> CadastrarProduto(ProdutoModel produtoModel)
        {
            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoModel));
            return Result<ProdutoModel>.Ok(produtoModel);
        }
    }
}
