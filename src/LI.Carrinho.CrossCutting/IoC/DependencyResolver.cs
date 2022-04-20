using LI.Carrinho.Application;
using LI.Carrinho.Application.Interfaces;
using LI.Carrinho.Domain.Interfaces;
using LI.Carrinho.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LI.Carrinho.CrossCutting.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<ICarrinhoApplication, CarrinhoApplication>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
        }
    }
}
