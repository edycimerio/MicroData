using Micro.Data.Domain.Interfaces.Repository;
using Micro.Data.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Micro.Data.Repository
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddRespositorys(this IServiceCollection services)
        {
            services.AddTransient<IItensPedidoRepository, ItensPedidoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();           

            return services;
        }
    }
}