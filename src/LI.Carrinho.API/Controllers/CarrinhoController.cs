using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Application.Models;
using LI.Carrinho.Domain.Interfaces.UnitOfWork;
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
    public class CarrinhoController : ApiBaseController
    {
        private readonly ICarrinhoApplication _carrinhoApplication;

        public CarrinhoController(ICarrinhoApplication carrinhoApplication)
        {
            _carrinhoApplication = carrinhoApplication;
        }

        /// <summary>
        /// Adicionar item ao carrinho
        /// </summary>
        /// <returns></returns>
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

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }
    }
}
