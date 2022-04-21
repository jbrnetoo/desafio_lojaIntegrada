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
    public class CupomController : ApiBaseController
    {
        private readonly ICupomApplication _cupomApplication;

        public CupomController(ICupomApplication cupomApplication)
        {
            _cupomApplication = cupomApplication;
        }

        /// <summary>
        /// Obter Cupons
        /// </summary>
        /// <returns>Retorna uma lista de cupons</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CupomModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterCupons()
        {
            var result = await _cupomApplication.ObterCupons();

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
        /// Obter Cupons
        /// </summary>
        /// <param name="codigo">Código do Cupom</param>
        /// <returns>Consulta informações de um cupom</returns>
        [HttpGet("{idCupom}")]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterCupomPeloId(Guid codigo)
        {
            var result = await _cupomApplication.ObterCupomPeloId(codigo);

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
        /// Obter Cupons
        /// </summary>
        /// <param name="cupomModel">Cupom a ser cadastrado</param>
        /// <returns>Retorna informações do cupom cadastrado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CadastrarCupom(CupomModel cupomModel)
        {
            var result = await _cupomApplication.CadastrarCupom(cupomModel);

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
        /// Atualizar cupom
        /// </summary>
        /// <param name="cupomModel">Cupom a ser atualizado</param>
        /// <returns>Retorna informações do cupom atualizado</returns>
        [HttpPut]
        [ProducesResponseType(typeof(CupomModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarCupom(CupomModel cupomModel)
        {
            var result = await _cupomApplication.AtualizarCupom(cupomModel);

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
