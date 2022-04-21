﻿using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.Carrinho.API.Controllers
{
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

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);

        }

        /// <summary>
        /// Obter cliente pelo documento
        /// </summary>
        /// <param name="documento">CPF do cliente</param>
        /// <returns>Consulta informações de um cliente</returns>
        [HttpGet("{documento}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterClientePorId(string documento)
        {
            var result = await _clienteApplication.ObterClientePeloDocumento(documento);

            if (result.Invalid)
            {
                var logMessage = MensagemErro(result.Notifications);

                Log.Error(logMessage);

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }

        /// <summary>
        /// Inserir cliente
        /// </summary>
        /// <param name="cliente">Cliente a ser inserido</param>
        /// <returns>Realiza cadastro de um cliente</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
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
        /// <returns>Realiza atualização de um cliente</returns>
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

                return BadRequest(new ErrorModel(result.Notifications));
            }

            return Ok(result.Object);
        }
    }
}
