using LI.Carrinho.Application;
using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Domain.Interfaces.Repositories;
using LI.Carrinho.Domain.Interfaces.UnitOfWork;
using LI.Carrinho.Infrastructure.Repository;
using LI.Carrinho.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace LI.Carrinho.CrossCutting.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
            RegisterUnitOfWork(services);
        }

        private static void RegisterUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkCarrinho, UnitOfWorkCarrinho>();
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();
            services.AddScoped<ICarrinhoApplication, CarrinhoApplication>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<IItemCarrinhoRepository, ItemCarrinhoRepository>();
        }
    }
}
