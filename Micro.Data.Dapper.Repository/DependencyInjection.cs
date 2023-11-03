using Micro.Data.Dapper.Repository.Repositories;
using Micro.Data.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Micro.Data.Dapper.Repository
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddDapperRespositorys(this IServiceCollection services)
        {
            services.AddTransient<IProdutoDapperRepository, ProdutoDapperRepository>();
            services.AddTransient<IPedidoDapperRepository, PedidoDapperRepository>();
            services.AddTransient<IProdutoDapperRepository, ProdutoDapperRepository>();

            return services;
        }
    }
}