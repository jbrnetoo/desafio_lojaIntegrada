using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.Carrinho.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ApiBaseController
    {
        private readonly IProdutoApplication _produtoApplication;

        public ProdutoController(IProdutoApplication produtoApplication)
        {
            _produtoApplication = produtoApplication;
        }

        /// <summary>
        /// Obter produtos
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutoModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterProdutos()
        {
            var result = await _produtoApplication.ObterProdutos();

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        /// <summary>
        /// Obter produto pelo codigo
        /// </summary>
        /// <param name="codigo">Código do produto</param>
        /// <returns>Consulta informações de um produto</returns>
        [HttpGet("{codigo}")]
        [ProducesResponseType(typeof(ProdutoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterProdutoPorId(Guid codigo)
        {
            var result = await _produtoApplication.ObterProdutoPeloId(codigo);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                if (result.StatusCode == StatusCodes.Status404NotFound)
                    return NotFound(new ErrorModel(result.Notifications));

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        /// <summary>
        /// Cadastrar produto
        /// </summary>
        /// <param name="produto">Produto a ser cadastrado</param>
        /// <returns>Cadastra um novo produto</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProdutoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarProduto(ProdutoModel produto)
        {
            var result = await _produtoApplication.CadastrarProduto(produto);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        /// <summary>
        /// Obter produto pelo codigo
        /// </summary>
        /// <param name="produto">Produto a ser atualizado</param>
        /// <returns>Realiza atualização de um produto</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ProdutoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarInformacoesProduto(ProdutoModel produto)
        {
            var result = await _produtoApplication.AtualizarProduto(produto);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                if (result.StatusCode == StatusCodes.Status404NotFound)
                    return NotFound(new ErrorModel(result.Notifications));

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }
    }
}
