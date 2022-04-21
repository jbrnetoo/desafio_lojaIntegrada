using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.Carrinho.API.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ApiBaseController
    {
        private readonly IClienteApplication _clienteApplication;

        public ClienteController(IClienteApplication clienteApplication)
        {
            _clienteApplication = clienteApplication;
        }

        /// <summary>
        /// Obter clientes
        /// </summary>
        /// <returns>Retorna uma lista de clientes</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ClienteModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClientes()
        {
            var result = await _clienteApplication.ObterClientes();

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
        /// Obter cliente pelo ID
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>Retorna informações do cliente</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClientePorId(Guid id)
        {
            var result = await _clienteApplication.ObterClientePeloId(id);

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
        /// Obter cliente pelo documento
        /// </summary>
        /// <param name="cpf">CPF do cliente</param>
        /// <returns>Retorna informações do cliente</returns>
        [HttpGet("documento/{cpf}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClientePeloDocumento(string cpf)
        {
            var result = await _clienteApplication.ObterClientePeloDocumento(cpf);

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
        /// Inserir cliente
        /// </summary>
        /// <param name="cliente">Cliente a ser inserido</param>
        /// <returns>Retorna informações do cliente cadastrado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarCliente(ClienteModel cliente)
        {
            var result = await _clienteApplication.InserirCliente(cliente);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        /// <summary>
        /// Atualizar informações de um cliente
        /// </summary>
        /// <param name="cliente">Cliente a ser atualizado</param>
        /// <returns>Retorna informações do cliente atualizado</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AtualizarCliente(ClienteModel cliente)
        {
            var result = await _clienteApplication.AtualizarInformacoes(cliente);

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
