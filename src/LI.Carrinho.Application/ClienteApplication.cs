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
    public class ClienteApplication : IClienteApplication
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplication(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<Result<List<ClienteModel>>> ObterClientes()
        {
            var clientes = await _clienteRepository.ObterTodos();
            return Result<List<ClienteModel>>.Ok(_mapper.Map<List<ClienteModel>>(clientes));
        }

        public async Task<Result<ClienteModel>> ObterClientePeloId(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);
            return Result<ClienteModel>.Ok(_mapper.Map<ClienteModel>(cliente));
        }

        public async Task<Result<ClienteModel>> ObterClientePeloDocumento(string documento)
        {
            var cliente = await _clienteRepository.ObterClientePorDocumento(documento);
            return Result<ClienteModel>.Ok(_mapper.Map<ClienteModel>(cliente));
        }

        public async Task<Result<ClienteModel>> InserirCliente(ClienteModel clienteModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteModel);
            await _clienteRepository.Adicionar(cliente);
            return Result<ClienteModel>.Ok(clienteModel);
        }

        public async Task<Result<ClienteModel>> AtualizarInformacoes(ClienteModel clienteModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteModel);
            await _clienteRepository.AtualizarInformacoes(cliente);

            return Result<ClienteModel>.Ok(clienteModel);
        }

        public async Task<Result<string>> RemoverCliente(Guid id)
        {
            await _clienteRepository.Remover(id);
            return Result<string>.Ok("Cliente removido.");
        }
    }
}
