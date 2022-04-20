using LI.Carrinho.Application.Models;
using LI.Carrinho.Application.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.Carrinho.Application.Interfaces
{
    public interface IClienteApplication
    {
        Task<Result<List<ClienteModel>>> ObterClientes();
        Task<Result<ClienteModel>> ObterClientePeloId(Guid id);
        Task<Result<ClienteModel>> InserirCliente(ClienteModel clienteModel);
        Task<Result<string>> RemoverCliente(Guid id);
        Task<Result<ClienteModel>> AtualizarInformacoes(ClienteModel clienteModel);
    }
}
