using Micro.Data.Domain.Interfaces.Repository;
using Micro.Data.Domain.Interfaces.Service;
using Micro.Data.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Micro.Data.Domain
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IItensPedidoService, ItensPedidoService>();
            services.AddTransient<IPedidoService, PedidoService>();

            return services;
        }
    }
}