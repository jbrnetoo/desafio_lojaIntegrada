using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
namespace LI.Carrinho.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarrinhoController : ApiBaseController
    {
        private readonly ICarrinhoApplication _carrinhoApplication;

        public CarrinhoController(ICarrinhoApplication carrinhoApplication)
        {
            _carrinhoApplication = carrinhoApplication;
        }

        /// <summary>
        /// Consulta o carrinho do cliente
        /// </summary>
        /// <param name="documento">Documento do cliente</param>
        /// <returns>Retorna o carrinho do cliente</returns>
        [HttpGet("{documento}")]
        [ProducesResponseType(typeof(CarrinhoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterCarrinho(string documento)
        {
            var result = await _carrinhoApplication.ObterCarrinho(documento);

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
        /// Adicionar item ao carrinho
        /// </summary>
        /// <param name="idProduto">ID do Produto</param>
        /// <param name="documento">Documento do cliente</param>
        /// <returns>Retorna o carrinho do cliente</returns>
        [HttpPost("adicionar-item")]
        [ProducesResponseType(typeof(CarrinhoModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AdicionarItemCarrinho(Guid idProduto, string documento)
        {
            var result = await _carrinhoApplication.AdicionarItem(idProduto, documento);

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
